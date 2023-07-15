using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentManagement.DTO
{
    public class ClassStudentDTO
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [Required, MaxLength(20)]
        public virtual string ClassId { get; set; } = string.Empty;
        [Required, MaxLength(20)]
        public string StudentId { get; set; } = string.Empty;
    }
}
