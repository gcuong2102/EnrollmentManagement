using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentManagement.Entity_Data
{
    [Table("SubjectTeacher")]
    public class SubjectTeacher
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [Required, MaxLength(20)]
        public string TeacherId { get; set; } = string.Empty;
        [ForeignKey("TeacherId")]
        public virtual Teachers? Teachers { get; set; }
        [Required, MaxLength(20)]
        public string SubjectId { get; set; } = string.Empty;
        [ForeignKey("SubjectId")]
        public virtual Subjects? Subjects { get; set; }
    }
}
