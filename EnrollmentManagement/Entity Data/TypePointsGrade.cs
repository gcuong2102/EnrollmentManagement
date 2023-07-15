using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentManagement.Entity_Data
{
    [Table("TypePointsGrade")]
    public class TypePointsGrade
    {
        [Key]
        [Required]
        public string Id { get; set; } = string.Empty;
        [Required,MaxLength(20)]
        public string TypePointId { get; set; } = string.Empty;
        [ForeignKey("TypePointId")]
        public virtual TypePoints? TypePoints { get; set; }
        [Required, MaxLength(20)]
        public string SubjectId { get; set; } = string.Empty;
        [ForeignKey("SubjectId")]
        public virtual Subjects? Subjects { get; set; }  
        [Required, MaxLength(20)]
        public string GradeId { get; set; } =string.Empty;
        [ForeignKey("GradeId")]
        public virtual Grades? Grades { get; set; }
        [Required]
        public int PointColumn { get; set; }
        [Required]
        public int RequiredPointColumn { get; set; }
    }
}
