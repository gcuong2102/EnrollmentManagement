using EnrollmentManagement.Entity_Data;
using EnrollmentManagement.Identity_Application;
using EnrollmentManagement.Models;
using EnrollmentManagement.RepositoriesInterface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace EnrollmentManagement.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly EnrollmentManagementDbContext dbContext;

        public RoleRepository(RoleManager<ApplicationRole> roleManager, EnrollmentManagementDbContext dbContext) 
        {
            this.roleManager = roleManager;
            this.dbContext = dbContext;
        }
        public async Task<List<ApplicationRole>> GetAllRolesAsync()
        {
            var rs = await roleManager.Roles.ToListAsync();
            return rs;
        }
        public async Task<ResultModel> AddRoleAsync(List<RoleModel> model)
        {
            try
            {
                foreach (var role in model)
                {
                    var newRole = new ApplicationRole()
                    {
                        Name = role.Name,
                        Descripstion = role.Description
                    };
                    var rs = await roleManager.CreateAsync(newRole);
                    if (!rs.Succeeded)
                    {
                        return new ResultModel(false, "Có lỗi xảy ra vui lòng kiểm tra lại");
                    }
                }
                await dbContext.SaveChangesAsync();
                return new ResultModel(true, "Thêm các vai trò thành công");
            }
            catch(Exception ex)
            {
                return new ResultModel(false, $"Có lỗi xảy ra vui lòng kiểm tra lại. Ex: {ex}");
            }
        }
        public async Task<ApplicationRole> FindRoleByIdAsync(string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);
            return role;
        }
        public async Task<ApplicationRole> FindRoleByNameAsync(string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            return role;
        }
        public async Task<ResultModel> UpdateRoleAsync(string roleId, ApplicationRole role)
        {
            try
            {
                var roleneed = await roleManager.FindByIdAsync(roleId);
                var rs = await roleManager.UpdateAsync(role);
                if (!rs.Succeeded)
                {
                    return new ResultModel(false, rs.Errors.First().Description);
                }
                return new ResultModel(true, "Cập nhật vai trò thành công");
            }
            catch (Exception ex)
            {
                return new ResultModel(false, $"Lỗi: {ex}");
            }
        }
        public async Task<ResultModel> DeleteRoleAsync(string roleId)
        {
            try
            {
                var role = await roleManager.FindByIdAsync(roleId);
                var rs = await roleManager.DeleteAsync(role);
                if (!rs.Succeeded)
                {
                    return new ResultModel(false, "Có lỗi xảy ra vui lòng thử lại");
                }
                return new ResultModel(true, "Xóa vai trò thành công");
            }
            catch (Exception ex)
            {
                return new ResultModel(false, $"Lỗi {ex}");
            }
        }
        public async Task<ResultModel> SetPermissionForRoleAsync(string roleId, List<long> listPermissionId)
        {
            try
            {
                foreach (var permissionId in listPermissionId)
                {
                    var permissionRole = new PermissionRole()
                    {
                        RoleId = roleId,
                        PermissionId = permissionId,
                    };
                    await dbContext.PermissionRole.AddAsync(permissionRole);
                }
                await dbContext.SaveChangesAsync();
                return new ResultModel(true, "Set quyền cho vai trò này thành công");
            }
            catch(Exception ex)
            {
                return new ResultModel(false, ex.Message);
            }

        }
    }
}
