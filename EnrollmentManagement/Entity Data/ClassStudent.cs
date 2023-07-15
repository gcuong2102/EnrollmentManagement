using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentManagement.Entity_Data
{
    [Table("ClassStudent")]
    public class ClassStudent
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [Required, MaxLength(20)]
        [DisplayName("Classes")]
        public string ClassId { get; set; } = string.Empty;
        [ForeignKey("ClassId")]
        public virtual Classes? Classes { get; set; }
        [Required, MaxLength(20)]
        [DisplayName("Students")]
        public string StudentId { get; set; } = string.Empty;
        [ForeignKey("StudentId")]
        public virtual Students? Students { get; set; }
    }
}
