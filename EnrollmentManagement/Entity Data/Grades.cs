using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentManagement.Entity_Data
{
    [Table("Grades")]
    public class Grades
    {
        [Key]
        [Required, MaxLength(20)]
        public string Id { get; set; } = string.Empty;
        [Required, MaxLength(30)]
        public string Name { get;set; } = string.Empty;
    }
}
