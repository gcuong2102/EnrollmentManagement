using EnrollmentManagement.Identity_Application;
using EnrollmentManagement.Models;

namespace EnrollmentManagement.RepositoriesInterface
{
    public interface IRoleRepository
    {
        public Task<List<ApplicationRole>> GetAllRolesAsync();
        public Task<ResultModel> AddRoleAsync(List<RoleModel> model);
        public Task<ApplicationRole> FindRoleByIdAsync(string roleId);
        public Task<ApplicationRole> FindRoleByNameAsync(string roleName);
        public Task<ResultModel> UpdateRoleAsync(string roleId, ApplicationRole role);
        public Task<ResultModel> DeleteRoleAsync(string roleId);
        public Task<ResultModel> SetPermissionForRoleAsync(string roleId, List<long> listPermissionId);
    }
}
