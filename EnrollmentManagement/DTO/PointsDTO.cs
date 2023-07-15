using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentManagement.DTO
{
    public class PointsDTO
    {
        [Key]
        [Required]
        public long Id { get; set; }
        public string TypePointId { get; set; } = string.Empty;
        public string StudentId { get; set;} = string.Empty;
        public string SubjectId { get; set; } = string.Empty;
        public bool Status { get; set; } = false;
    }
}
