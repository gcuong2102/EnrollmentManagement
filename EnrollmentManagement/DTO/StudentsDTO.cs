using EnrollmentManagement.Identity_Application;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentManagement.DTO
{
    public class StudentsDTO
    {
        [Required, MaxLength(20)]
        public string Id { get; set; } = string.Empty;
        [Required, MaxLength(450)]
        public virtual string UserId { get; set; } = string.Empty;
        [ForeignKey("UserId")]
        public virtual ApplicationUser? ApplicationUser { get; set; }
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
        [MaxLength(100)]
        public string ParentName { get; set; } = string.Empty;
        [MaxLength(15)]
        public string Phone { get; set; } = string.Empty;
        [MaxLength(150)]
        public string ImageUrl { get; set; } = string.Empty;
        [MaxLength(30), Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
