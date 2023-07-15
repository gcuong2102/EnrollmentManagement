using EnrollmentManagement.Models;
using EnrollmentManagement.RepositoriesInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnrollmentManagement.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository repo;

        public StudentsController(IStudentRepository repo) 
        {
            this.repo = repo;
        }
        [HttpGet("GetStudents")]
        public async Task<IActionResult> GetStudents()
        {
            var rs = await repo.GetStudentsAsync();
            return Ok(rs);
        }
        [HttpGet("FindStudent")]
        public async Task<IActionResult> FindStudent(string searchString)
        {
            var rs = await repo.FindStudentByAsync(searchString);
            return Ok(rs);
        }        
        [HttpGet("GetClassOfStudent")]
        public async Task<IActionResult> GetClassOfStudent(string studentId)
        {
            var rs = await repo.GetClassOfStudentAsync(studentId);
            return Ok(rs);
        }
        [HttpPost("AddStudent")]
        public async Task<IActionResult> AddStudent(RegisterModel model)
        {
            var rs = await repo.AddStudentAsync(model);
            return Ok(rs);
        }
        [HttpPost("CollectTuitionFee")]
        public async Task<IActionResult> CollectTuitionFee(TuitionModel model)
        {
            var rs = await repo.CollectTuitionFeeAsync(model);
            return Ok(rs);
        }
        [HttpDelete("DeleteStudent")]
        public async Task<IActionResult> AddStudent(string studentId)
        {
            var rs = await repo.DeleteStudentAsync(studentId);
            return Ok(rs);
        }

    }
}
