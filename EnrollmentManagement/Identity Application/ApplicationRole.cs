using Microsoft.AspNetCore.Identity;

namespace EnrollmentManagement.Identity_Application
{
    public class ApplicationRole : IdentityRole
    {
        public override string Name { get; set; } = string.Empty;
        public string Descripstion { get; set; } = string.Empty;
    }
}
