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
    public class PermissionRepository : IPermissionRepository
    {
        private readonly EnrollmentManagementDbContext dbContext;
        private readonly IMapper mapper;

        public PermissionRepository(EnrollmentManagementDbContext dbContext,IMapper mapper) 
        { 
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<ResultModel> AddPermissionsAsync(List<PermissionModel> models)
        {
            try
            {
                foreach (var permission in models)
                {
                    var newPermission = new Permissions()
                    {
                        Name = permission.Name,
                        Description = permission.Description
                    };
                    var rs = await dbContext.Permissions.AddAsync(newPermission);
                }
                await dbContext.SaveChangesAsync();
                return new ResultModel(true, "Thêm các chức năng thành công thành công");
            }
            catch (Exception ex)
            {
                return new ResultModel(false, $"Có lỗi xảy ra vui lòng kiểm tra lại. Ex: {ex}");
            }
        }

        public async Task<List<PermissionDTO>> GetPermissionsAsync()
        {
            List<Permissions> result = await dbContext.Permissions.ToListAsync();
            return mapper.Map<List<PermissionDTO>>(result);
        }
    }
}
