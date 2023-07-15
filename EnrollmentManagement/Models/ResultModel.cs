using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagement.Models
{
    public class ResultModel
    {
        public ResultModel(bool status, string message) 
        {
            Status = status;
            Message = message;
        }
        [Required]
        public bool Status { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
