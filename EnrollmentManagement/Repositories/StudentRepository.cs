using AutoMapper;
using EnrollmentManagement.DTO;
using EnrollmentManagement.Entity_Data;
using EnrollmentManagement.Identity_Application;
using EnrollmentManagement.Models;
using EnrollmentManagement.RepositoriesInterface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EnrollmentManagement.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly EnrollmentManagementDbContext dbContext;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;

        public StudentRepository(EnrollmentManagementDbContext dbContext, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.userManager = userManager;
        }
        private string CreateUserName()
        {
            var now = DateTime.Now;
            return now.Year.ToString() + now.Month.ToString() + "-" + now.Day.ToString() + now.Hour.ToString() + now.Minute.ToString() + now.Second.ToString() + now.Millisecond.ToString();
        }
        public async Task<ResultModel> AddStudentAsync(RegisterModel model)
        {
            try
            {
                var newUser = new ApplicationUser()
                {
                    UserName = CreateUserName(),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    CreatedDate = DateTime.Now,
                    Status = true,
                };
                var result = await userManager.CreateAsync(newUser, model.Password);
                if (!result.Succeeded)
                {
                    return new ResultModel(false, result.Errors.FirstOrDefault().Description.ToString());
                }
                var newStudents = new Students()
                {
                    Id = Functions.Functions.CreateKey("ST"),
                    UserId = newUser.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Address,
                    Birthday = model.BirthDay,
                    Email = model.Email,
                    ImageUrl = model.ImageUrl,
                    ParentName = model.ParentName,
                    Phone = model.PhoneNumber,
                    Sex = model.Sex,
                };
                var addStudent = await dbContext.Students.AddAsync(newStudents);
                await dbContext.SaveChangesAsync();

                return new ResultModel(true, $"Tạo học sinh thành công, sử dụng '{newUser.UserName}' để đăng nhập");
            }
            catch (Exception ex)
            {
                return new ResultModel(false, ex.ToString());
            }
        }
        public async Task<ResultModel> CollectTuitionFeeAsync(TuitionModel model)
        {
            try
            {
                var receipt = new TuitionsDTO()
                {
                    ClassId = model.ClassId,
                    CreatedDate = DateTime.Now,
                    Description = model.Description,
                    Discount = model.Discount,
                    Status = model.Status,
                    StudentId = model.StudentId,
                    Surcharge = model.Surcharge,
                    Tuition = model.Tuition,
                };
                await dbContext.Tuitions.AddAsync(mapper.Map<Tuitions>(receipt));
                await dbContext.SaveChangesAsync();
                return new ResultModel(true, "Thu học phí học viên thành công!");
            }
            catch (Exception ex)
            {
                return new ResultModel(false, $"Lỗi: {ex}");
            }

        }
        public async Task<ResultModel> DeleteStudentAsync(string StudentId)
        {
            try
            {
                var student = await dbContext.Students.FindAsync(StudentId);
                var account = await userManager.FindByNameAsync(student.UserId);
                dbContext.Students.Remove(student);
                await dbContext.SaveChangesAsync();
                await userManager.DeleteAsync(account);
                return new ResultModel(true, "Xóa học viên thành công!");
            }
            catch (Exception ex)
            {
                return new ResultModel(false, $"Lỗi: {ex}");
            }
        }
        public async Task<StudentsDTO> FindStudentByAsync(string searchString)
        {
            var student = await dbContext.Students.Where(x => x.Id.Contains(searchString) || x.Phone.Contains(searchString) || x.Email.Contains(searchString) || x.FirstName.Contains(searchString) || x.LastName.Contains(searchString)).ToListAsync();
            if(student.Count == 0)
            {
                return new StudentsDTO();
            }
            return mapper.Map<StudentsDTO>(student.SingleOrDefault());
        }
        public async Task<List<ClassesDTO>> GetClassOfStudentAsync(string StudentId)
        {
            var classStudent =  await dbContext.ClassStudents.Where(x=>x.StudentId == StudentId).ToListAsync();
            var result = new List<ClassesDTO>();
            foreach (var classId in classStudent) 
            {
                var classes = await dbContext.Classes.FindAsync(classId);
                result.Add(mapper.Map<ClassesDTO>(classes));
            }
            return result;
        }
        //Not Complete
        public Task<List<ClassesDTO>> GetScheduleOfStudentAsync(string StudentId)
        {
            throw new NotImplementedException();
        }
        public async Task<List<StudentsDTO>> GetStudentsAsync()
        {
            var result = await dbContext.Students.ToListAsync();
            return mapper.Map<List<StudentsDTO>>(result);
        }

        public async Task<ResultModel> UpdateStudentAsync(string StudentId, RegisterModel model)
        {
            try
            {
                var student = await dbContext.Students.FindAsync(StudentId);
                student.FirstName = model.FirstName;
                student.LastName = model.LastName;
                student.Email = model.Email;
                student.Address = model.Address;
                student.Phone = model.PhoneNumber;
                student.Birthday = model.BirthDay;
                student.Sex = model.Sex;
                student.ImageUrl = model.ImageUrl;
                student.ParentName = model.ParentName;
                var account = await userManager.FindByIdAsync(student.UserId);
                account.FirstName = model.FirstName;
                account.LastName = model.LastName;
                account.Email = model.Email;
                account.PhoneNumber = model.PhoneNumber;
                await userManager.UpdateAsync(account);
                await dbContext.SaveChangesAsync();
                return new ResultModel(true, "Cập nhật học viên thành công");
            }
            catch(Exception ex)
            {
                return new ResultModel(false, $"Lỗi: {ex}");
            }
            
        }
    }
}
