using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentManagement.Entity_Data
{
    [Table("Subjects")]
    public class Subjects
    {
        [Key]
        [Required,MaxLength(20)]
        public string Id { get; set; } = string.Empty;
        [Required,MaxLength(30)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(150)]
        public string Description { get; set; } = string.Empty;
        [Required,MaxLength(20)]
        public string DepartmentId { get; set; } = string.Empty;
        [ForeignKey("DepartmentId")]
        public virtual Departments? Departments { get; set; }
        [Required, MaxLength(20)]
        public string GradeId { get; set;} = string.Empty;
        [ForeignKey("GradeId")]
        public virtual Grades? Grades { get; set; }

    }
}
