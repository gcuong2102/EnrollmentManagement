namespace EnrollmentManagement.Models
{
    public class SetPermissionForRoleModel
    {
        public string RoleId { get; set; } = string.Empty;
        public List<long> PermissionId { get; set; } = new List<long>();
    }
}
