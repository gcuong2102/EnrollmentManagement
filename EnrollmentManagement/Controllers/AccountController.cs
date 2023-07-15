using EnrollmentManagement.Models;
using EnrollmentManagement.RepositoriesInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnrollmentManagement.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository repo;

        public AccountController(IAccountRepository repo) 
        { 
            this.repo = repo;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await repo.LoginAsync(model);
            if (!result.Status)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
        [HttpPost("StudentRegister")]
        public async Task<IActionResult> RegisterStudent(RegisterModel model)
        {
            var result = await repo.RegisterStudentAsync(model);
            if (!result.Status)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
    }
}
