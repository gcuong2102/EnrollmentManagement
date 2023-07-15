using EnrollmentManagement.DTO;
using EnrollmentManagement.Entity_Data;
using EnrollmentManagement.Models;

namespace EnrollmentManagement.RepositoriesInterface
{
    public interface IStudentRepository
    {
        public Task<List<StudentsDTO>> GetStudentsAsync();
        public Task<ResultModel> AddStudentAsync(RegisterModel model);
        public Task<List<ClassesDTO>> GetClassOfStudentAsync(string StudentId);
        public Task<ResultModel> CollectTuitionFeeAsync(TuitionModel model);
        public Task<List<ClassesDTO>> GetScheduleOfStudentAsync(string StudentId);
        public Task<StudentsDTO> FindStudentByAsync(string SearchString);
        public Task<ResultModel> UpdateStudentAsync(string StudentId, RegisterModel model);
        public Task<ResultModel> DeleteStudentAsync(string StudentId);
    }
}
