using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentManagement.DTO
{
    public class SubjectTeacherDTO
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [Required, MaxLength(20)]
        public string TeacherId { get; set; } = string.Empty;
        [Required, MaxLength(20)]
        public string SubjectId { get; set; } = string.Empty;
    }
}
