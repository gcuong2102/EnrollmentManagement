using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentManagement.DTO
{
    public class ClassesDTO
    {
        [Key]
        [Required, MaxLength(20)]
        public string Id { get; set; } = string.Empty;
        [Required, MaxLength(30)]
        public string Name { get; set;} = string.Empty;
        [Required, MaxLength(20)]
        public string GradeId { get; set; } = string.Empty;
        public string Description { get; set;} = string.Empty;
        [Required, MaxLength(20)]
        public string CourseId { get; set;} = string.Empty;
        [MaxLength(150)]
        public string ImageUrl { get; set;} = string.Empty;
        [Required]
        public bool Status { get; set; }
        [Required]
        public float Double { get; set; }
        [Required]
        public int NumberOfStudent { get; set; }
    }
}
