using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentManagement.DTO
{
    public class SubjectsDTO
    {
        [Key]
        [Required]
        public string Id { get; set; } = string.Empty;
        [Required,MaxLength(30)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(150)]
        public string Description { get; set; } = string.Empty;
        [Required,MaxLength(20)]
        public string DepartmentId { get; set; } = string.Empty;
        [Required, MaxLength(20)]
        public string GradeId { get; set;} = string.Empty;

    }
}
