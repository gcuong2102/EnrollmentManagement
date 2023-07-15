using EnrollmentManagement.Identity_Application;
using EnrollmentManagement.Models;
using EnrollmentManagement.RepositoriesInterface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EnrollmentManagement.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UserRepository(UserManager<ApplicationUser> userManager) 
        { 
            this.userManager = userManager;
        }
        public Task<ResultModel> AddUserAsync(RegisterModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> FindUserByUserNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ApplicationUser>> GetUsersAsync()
        {
            var rs = await userManager.Users.ToListAsync();
            return rs;
        }

        public Task<ResultModel> RemoveUserAsync(string UserId)
        {
            throw new NotImplementedException();
        }

        public Task<ResultModel> UpdateUserAsync(string UserId, ApplicationUser model)
        {
            throw new NotImplementedException();
        }
    }
}
