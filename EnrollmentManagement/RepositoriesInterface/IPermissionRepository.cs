using EnrollmentManagement.DTO;
using EnrollmentManagement.Models;

namespace EnrollmentManagement.RepositoriesInterface
{
    public interface IPermissionRepository
    {
        public Task<List<PermissionDTO>> GetPermissionsAsync();
        public Task<ResultModel> AddPermissionsAsync(List<PermissionModel> models);
    }
}
