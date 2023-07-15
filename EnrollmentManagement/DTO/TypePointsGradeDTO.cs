using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentManagement.DTO
{
    public class TypePointsGradeDTO
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [Required,MaxLength(20)]
        public string TypePointId { get; set; } = string.Empty;
        [Required, MaxLength(20)]
        public string SubjectId { get; set; } = string.Empty;
        [Required, MaxLength(20)]
        public string GradeId { get; set; } =string.Empty;
        [Required]
        public int PointColumn { get; set; }
        [Required]
        public int RequiredPointColumn { get; set; }
    }
}
