using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentManagement.DTO
{
    public class RegistrationsDTO
    {
        [Key]
        [Required,MaxLength(20)]
        public string Id { get; set; } = string.Empty;
        [Required, MaxLength(20)]
        public string StudentId { get; set; } = string.Empty;
        [Required, MaxLength(20)]
        public string ClassId { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }

    }
}
