using EnrollmentManagement.Identity_Application;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentManagement.Entity_Data
{
    [Table("PermissionRole")]
    public class PermissionRole
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [Required]
        public long? PermissionId { get; set; }
        [ForeignKey("PermissionId")]
        public Permissions? Permission { get; set; }
        [Required,MaxLength(450)]
        public string RoleId { get; set; } = string.Empty;
        [ForeignKey("RoleId")]
        public ApplicationRole? ApplicationRole { get; set; }
    }
}
