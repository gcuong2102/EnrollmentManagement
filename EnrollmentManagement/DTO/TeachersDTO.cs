using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentManagement.DTO
{
    public class TeachersDTO
    {
        [Key]
        [Required, MaxLength(20)]
        public string ID { get; set; } = string.Empty;
        [Required, MaxLength(30)]
        public string LastName { get; set; } = string.Empty;
        [Required, MaxLength(30)]
        public string FirstName { get; set; } = string.Empty;
        [Required, Range(0, 1)]
        public int Sex { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [MaxLength(150, ErrorMessage = "Vui lòng nhập dưới 150 ký tự")]
        public string Address { get; set; } = string.Empty;
        [MaxLength(15)]
        public string Phone { get; set; } = string.Empty;
        [MaxLength(150)]
        public string ImageUrl { get; set; } = string.Empty;
        [MaxLength(30), Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string TaxIdentificationNumber { get; set; } = string.Empty;
        [Required,MaxLength(15)]
        public string MainSubject { get; set; } = string.Empty;
        [Required]
        public float Salary { get; set; } = 0;
        [Required]
        public bool Status { get; set; } = false;
        [Required,MaxLength(30)]
        public string CreatedBy { get; set; } = string.Empty;
    }
}
