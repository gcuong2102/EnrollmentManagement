using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentManagement.DTO
{
    public class SchedulesDTO
    {
        [Key]
        [Required, MaxLength(20)]
        public string Id { get; set; } = string.Empty;
        [Required,MaxLength(20)]
        public string ClassId { get; set; } = string.Empty;
        [Required, MaxLength(20)]
        public string RoomId { get; set; } = string.Empty;
        [Required, MaxLength(20)]
        public string TeacherId { get; set; } = string.Empty;
        [Required, MaxLength(20)]
        public string SubjectId { get; set; } = string.Empty;
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime FinishTime { get; set; }
        [Required]
        public DateTime StartDate { get;set; }
        [Required]
        public DateTime FinishDate { get;set; }
        [Required]
        public long WeekdayId { get; set; }

    }
}
