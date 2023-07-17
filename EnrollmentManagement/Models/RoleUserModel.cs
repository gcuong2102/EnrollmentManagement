using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagement.Models
{
    public class RoleUserModel
    {
        [Required]
        public string RoleId { get; set; } = string.Empty;
        [Required]
        public string UserId { get; set; } = string.Empty;
    }
}
