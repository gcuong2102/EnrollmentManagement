using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentManagement.DTO
{
    public class CoursesDTO
    {
        [Key]
        [Required]
        public string Id { get; set; } = string.Empty;
        [Required, MaxLength(30)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime FinishDate { get; set; }
    }
}
