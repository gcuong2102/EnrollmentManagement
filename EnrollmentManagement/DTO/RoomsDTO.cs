using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentManagement.DTO
{
    public class RoomsDTO
    {
        [Key]
        [Required,MaxLength(30)]
        public string Id { get;set; } = string.Empty;
        [Required,MaxLength(30)]
        public string Name { get; set; } = string.Empty;
    }
}
