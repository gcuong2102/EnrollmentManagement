using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentManagement.DTO
{
    public class TypePointsDTO
    {
        [Key]
        [Required, MaxLength(20)]
        public string Id { get; set; } = string.Empty;
        [Required, MaxLength(30)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int Factor { get; set; }
    }
}
