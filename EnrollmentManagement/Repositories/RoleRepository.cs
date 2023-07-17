using AutoMapper;
using EnrollmentManagement.DTO;
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
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManger;

        public RoleRepository(RoleManager<ApplicationRole> roleManager, EnrollmentManagementDbContext dbContext, IMapper mapper, UserManager<ApplicationUser> userManager) 
        {
            this.roleManager = roleManager;
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.userManger = userManager;
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
        public async Task<RoleAndPermissionModel> FindRoleByIdAsync(string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);
            var listPermission = await dbContext.PermissionRole.Where(x=>x.RoleId == role.Id).ToListAsync();
            var newlistPermission = new List<Permissions>();
            foreach (var permissionRole in listPermission)
            {
                var permisison = await dbContext.Permissions.FindAsync(permissionRole.PermissionId);
                newlistPermission.Add(permisison);
            }
            var result = new RoleAndPermissionModel() { 
                RoleName = role.Name,
                Description = role.Descripstion,
                Permissions = mapper.Map<List<PermissionDTO>>(newlistPermission)
            };
            return result;
        }
        public async Task<RoleAndPermissionModel> FindRoleByNameAsync(string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            var listPermission = await dbContext.PermissionRole.Where(x => x.RoleId == role.Id).ToListAsync();
            var newlistPermission = new List<Permissions>();
            foreach (var permissionRole in listPermission)
            {
                var permisison = await dbContext.Permissions.FindAsync(permissionRole.PermissionId);
                newlistPermission.Add(permisison);
            }
            var result = new RoleAndPermissionModel()
            {
                RoleName = role.Name,
                Description = role.Descripstion,
                Permissions = mapper.Map<List<PermissionDTO>>(newlistPermission)
            };
            return result;
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
        public async Task<ResultModel> SetRoleForUserAsync(RoleUserModel model)
        {
            try
            {
                var role = await roleManager.FindByIdAsync(model.RoleId);
                if(role == null)
                {
                    return new ResultModel(false, "Vui lòng kiểm tra lại tên vai trò");
                }
                var user = await userManger.FindByIdAsync(model.UserId);
                await userManger.AddToRoleAsync(user, role.Name);
                return new ResultModel(true, "Cập nhật quyền người dùng thành công");
            }
            catch (Exception ex)
            {
                return new ResultModel(false, ex.Message);
            }
        }
    }
}
