using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentManagement.Entity_Data
{
    [Table("Tuitions")]
    public class Tuitions
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [Required,MaxLength(20)]
        public string StudentId { get; set; } = string.Empty;
        [ForeignKey("StudentId")]
        public virtual Students? Students { get; set; }
        [Required, MaxLength(20)]
        public string ClassId { get; set; } = string.Empty;
        [ForeignKey("ClassId")]
        public virtual Classes? Classes { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [MaxLength(150)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public float Tuition { get; set; }
        [Required]
        public float Surcharge { get; set; } = 0;
        [Required]
        public float Discount { get; set; } = 0;
        [Required]
        public bool Status { get; set; } = false;
    }
}
