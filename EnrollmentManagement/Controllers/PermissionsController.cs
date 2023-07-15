using EnrollmentManagement.Models;
using EnrollmentManagement.RepositoriesInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnrollmentManagement.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionRepository repo;

        public PermissionsController(IPermissionRepository repo)
        {
            this.repo = repo;
        }
        [HttpGet("GetAllPermissions")]
        public async Task<IActionResult> GetPermissions()
        {
            var rs = await repo.GetPermissionsAsync();
            return Ok(rs);
        }
        [HttpPost("AddPermissions")]
        [Authorize]
        public async Task<IActionResult> AddPermissions(List<PermissionModel> model)
        {
            var rs = await repo.AddPermissionsAsync(model);
            return Ok(rs.Message);
        }
    }
}
