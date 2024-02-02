#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SignInSystem.Entity
{
    public class Salary
    {
        [Key]
        public string SalaryID { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "% giảm giá phải nằm trong khoảng 1% đến 100%")]
        public string LecturerSalaryPercentStudent { get; set; }

        public string SalaryAllowance { get; set; } 

        public string Note { get;set; }

        public string TotalSalary { get; set; }

        [ForeignKey("Teacher")]
        public string TeacherID { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
