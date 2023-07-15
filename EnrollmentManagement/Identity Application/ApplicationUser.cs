using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagement.Identity_Application
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get;set; }
        public string? LastName { get;set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public string CreatedBy { get; set; } = string.Empty;
    }
}
