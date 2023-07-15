using EnrollmentManagement.Models;
using EnrollmentManagement.RepositoriesInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnrollmentManagement.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleRepository repo;

        public RolesController(IRoleRepository repo) 
        {
            this.repo = repo;
        }
        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetRole()
        {
            var rs = await repo.GetAllRolesAsync();
            return Ok(rs);
        }
        [HttpPost("AddRoles")]
        public async Task<IActionResult> AddRole(List<RoleModel> model)
        {
            var rs = await repo.AddRoleAsync(model);
            return Ok(rs);
        }
        [HttpPost("FindRoleById")]
        public async Task<IActionResult> FindRoleById(string roleId)
        {
            var rs = await repo.FindRoleByIdAsync(roleId);
            return Ok(rs);
        }
        [HttpPost("FindRoleByName")]
        public async Task<IActionResult> FindRoleByName(string roleName)
        {
            var rs = await repo.FindRoleByNameAsync(roleName);
            return Ok(rs);
        }
        [HttpPost("UpdateRole")]
        public async Task<IActionResult> UpdateRole(RoleUpdateModel model)
        {
            var rs = await repo.UpdateRoleAsync(model.RoleId,model.Role);
            return Ok(rs);
        }
        [HttpPost("DeleteRole")]
        public async Task<IActionResult> DeleteRole(string roleId)
        {
            var rs = await repo.DeleteRoleAsync(roleId);
            return Ok(rs);
        }
        [HttpPost("SetPermissionForRole")]
        public async Task<IActionResult> SetPermissionForRole(SetPermissionForRoleModel model)
        {
            var rs = await repo.SetPermissionForRoleAsync(model.RoleId,model.PermissionId);
            return Ok(rs);
        }
    }
}
