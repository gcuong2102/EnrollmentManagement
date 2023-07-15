using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentManagement.Entity_Data
{
    [Table("Classes")]
    public class Classes
    {
        [Key]
        [Required, MaxLength(20)]
        public string Id { get; set; } = string.Empty;
        [Required, MaxLength(30)]
        public string Name { get; set;} = string.Empty;
        [Required, MaxLength(20)]
        [DisplayName("Grades")]
        public string GradeId { get; set; } = string.Empty;
        [ForeignKey("GradeId")]
        public virtual Grades? Grades { get; set; }
        [MaxLength(200)]
        public string Description { get; set;} = string.Empty;
        [Required, MaxLength(20)]
        [DisplayName("Courses")]
        public string CourseId { get; set;} = string.Empty;
        [ForeignKey("CourseId")]
        public virtual Courses? Courses { get; set; }
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
