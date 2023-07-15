using EnrollmentManagement.Entity_Data;
using EnrollmentManagement.Identity_Application;
using EnrollmentManagement.Models;
using EnrollmentManagement.RepositoriesInterface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EnrollmentManagement.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IConfiguration configuration;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly EnrollmentManagementDbContext dbContext;

        public AccountRepository(SignInManager<ApplicationUser> signInManager, IConfiguration configuration, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, EnrollmentManagementDbContext dbContext)
        {
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.dbContext = dbContext;
        }
        public async Task<ResultModel> LoginAsync(LoginModel loginModel)
        {
            try
            {
                var result = await signInManager.PasswordSignInAsync(loginModel.Username, loginModel.Password, false, false);
                if (!result.Succeeded) return new ResultModel(false, "Sai tài khoản hoặc mật khẩu, vui lòng kiểm tra lại");
                var user = await userManager.FindByNameAsync(loginModel.Username);
                var token = await CreateTokenAsync(user);
                return new ResultModel(true, new JwtSecurityTokenHandler().WriteToken(token));
            }
            catch (Exception ex)
            {
                return new ResultModel(false, "Lỗi: " + ex.ToString());
            }

        }
        public Task<ResultModel> LoginTeacherAsync(LoginModel loginModel)
        {
            throw new NotImplementedException();
        }
        public async Task<ResultModel> RegisterStudentAsync(RegisterModel registerModel)
        {
            try
            {
                var newUser = new ApplicationUser()
                {
                    UserName = CreateUserName(),
                    FirstName = registerModel.FirstName,
                    LastName = registerModel.LastName,
                    Email = registerModel.Email,
                    CreatedDate = DateTime.Now,
                    Status = true,
                };
                var result = await userManager.CreateAsync(newUser, registerModel.Password);
                if (!result.Succeeded)
                {
                    return new ResultModel(false, result.Errors.FirstOrDefault().Description.ToString());
                }
                var newStudents = new Students()
                {
                    Id = Functions.Functions.CreateKey("ST"),
                    UserId = newUser.Id,
                    FirstName = registerModel.FirstName,
                    LastName = registerModel.LastName,
                    Address = registerModel.Address,
                    Birthday = registerModel.BirthDay,
                    Email = registerModel.Email,
                    ImageUrl = "",
                    ParentName = registerModel.ParentName,
                    Phone = registerModel.PhoneNumber,
                    Sex = registerModel.Sex,
                };
                var addStudent = await dbContext.Students.AddAsync(newStudents);
                await dbContext.SaveChangesAsync();

                return new ResultModel(true, $"Tạo tài khoản học sinh thành công, sử dụng '{newUser.UserName}' để đăng nhập");
            }
            catch (Exception ex)
            {
                return new ResultModel(false, ex.ToString());
            }

        }
        private string CreateUserName()
        {
            var now = DateTime.Now;
            return now.Year.ToString() + now.Month.ToString() + "-" + now.Day.ToString() + now.Hour.ToString() + now.Minute.ToString() + now.Second.ToString() + now.Millisecond.ToString();
        }
        public async Task<JwtSecurityToken> CreateTokenAsync(ApplicationUser user)
        {
            var roleList = await roleManager.Roles.Where(x => x.Id == user.Id).ToListAsync();
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            };
            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: configuration["JWT:Issuer"],
                audience: configuration["JWT:Audience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
                );
            return token;
        }
        public Task<ResultModel> RegisterManganerAsync(RegisterModel registerModel)
        {
            throw new NotImplementedException();
        }
    }
}
