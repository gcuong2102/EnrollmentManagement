using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EnrollmentManagement.Entity_Data
{
    [Table("Schedules")]
    public class Schedules
    {
        [Key]
        [Required, MaxLength(20)]
        public string Id { get; set; } = string.Empty;

        [Required, MaxLength(20)]
        public string ClassId { get; set; } = string.Empty;
        [ForeignKey("ClassId")]
        public virtual Classes? Classes { get; set; }

        [Required, MaxLength(20)]
        public string RoomId { get; set; } = string.Empty;
        [ForeignKey("RoomId")]
        public virtual Rooms? Rooms { get; set; }
        [Required, MaxLength(20)]
        public string TeacherId { get; set; } = string.Empty;
        [ForeignKey("TeacherId")]
        public virtual Teachers? Teachers { get; set; }

        [Required, MaxLength(20)]
        public string SubjectId { get; set; } = string.Empty;
        [ForeignKey("SubjectId")]
        public virtual Subjects? Subjects { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime FinishTime { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime FinishDate { get; set; }

        [Required,MaxLength(20)]
        public string WeekdayId { get; set; } = string.Empty;
        [ForeignKey("WeekdayId")]
        public virtual Weekdays? Weekdays { get; set; }
    }
}
