using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagement.Models
{
    public class RegisterModel
    {
        [Required]
        public string FirstName { get;set; } = string.Empty;
        [Required]
        public string LastName { get;set; } = string.Empty;
        [Required]
        public string Email { get;set; } = string.Empty;
        [Required]
        public DateTime BirthDay { get;set; }
        [Required]
        public int Sex { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string ParentName { get; set; } = string.Empty;
        [Required]
        public string Password { get;set; } = string.Empty;

    }
}
