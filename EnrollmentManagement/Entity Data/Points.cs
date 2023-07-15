using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentManagement.Entity_Data
{
    [Table("Points")]
    public class Points
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [Required, MaxLength(20)]
        public string TypePointId { get; set; } = string.Empty;
        [Required, MaxLength(20)]
        [DisplayName("Students")]
        public string StudentId { get; set; } = string.Empty;
        [ForeignKey("StudentId")]
        public virtual Students? Students {get;set;}
        [Required, MaxLength(20)]
        [DisplayName("Subjects")]
        public string SubjectId { get; set; } = string.Empty;
        [ForeignKey("SubjectId")]
        public virtual Subjects? Subjects { get; set; }
        [Required]
        public bool Status { get; set; } = false;
    }
}
