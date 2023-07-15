using EnrollmentManagement.Models;
using Microsoft.AspNetCore.Identity;

namespace EnrollmentManagement.RepositoriesInterface
{
    public interface IAccountRepository
    {
        public Task<ResultModel> LoginAsync(LoginModel loginModel);
        public Task<ResultModel> LoginTeacherAsync(LoginModel loginModel);
        public Task<ResultModel> RegisterStudentAsync(RegisterModel registerModel);
        public Task<ResultModel> RegisterManganerAsync(RegisterModel registerModel);
    }
}
