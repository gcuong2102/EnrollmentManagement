using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagement.DTO
{
    public class PermissionDTO
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;
    }
}
