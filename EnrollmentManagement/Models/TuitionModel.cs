using EnrollmentManagement.Entity_Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagement.Models
{
    public class TuitionModel
    {
        [Required, MaxLength(20)]
        public string StudentId { get; set; } = string.Empty;
        [Required, MaxLength(20)]
        public string ClassId { get; set; } = string.Empty;
        public string TypeTuition { get; set; } = string.Empty;
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
