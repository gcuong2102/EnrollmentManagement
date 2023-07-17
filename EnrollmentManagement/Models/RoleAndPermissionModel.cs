using EnrollmentManagement.DTO;

namespace EnrollmentManagement.Models
{
    public class RoleAndPermissionModel
    {
        public string RoleName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<PermissionDTO>? Permissions { get; set; }
    }
}
