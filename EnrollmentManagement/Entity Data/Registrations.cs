using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentManagement.Entity_Data
{
    [Table("Registrations")]
    public class Registrations
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [Required, MaxLength(20)]
        public string StudentId { get; set; } = string.Empty;
        [ForeignKey("StudentId")]
        public virtual Students? Students { get; set; }
        [Required, MaxLength(20)]
        public string ClassId { get; set; } = string.Empty;
        [ForeignKey("ClassId")]
        public virtual Classes? Classes { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }

    }
}
