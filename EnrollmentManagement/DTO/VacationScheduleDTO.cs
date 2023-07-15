using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentManagement.DTO
{
    public class VacationScheduleDTO
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [Required,MaxLength(50)]
        public string Name { set; get; } = string.Empty;
        [MaxLength(150)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime FinishDate { get; set; }
    }
}
