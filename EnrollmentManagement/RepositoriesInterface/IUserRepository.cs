using EnrollmentManagement.Identity_Application;
using EnrollmentManagement.Models;

namespace EnrollmentManagement.RepositoriesInterface
{
    public interface IUserRepository
    {
        public Task<List<ApplicationUser>> GetUsersAsync();
        public Task<ResultModel> AddUserAsync(RegisterModel model);
        public Task<ResultModel> UpdateUserAsync(string UserId,ApplicationUser model);
        public Task<ResultModel> RemoveUserAsync(string UserId);
        public Task<ApplicationUser> FindUserByUserNameAsync(string userName);
    }
}
