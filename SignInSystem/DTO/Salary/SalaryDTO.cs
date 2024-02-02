using System.ComponentModel.DataAnnotations;
#nullable disable
namespace SignInSystem.DTO.Salary
{
    public class SalaryDTO
    {
        [Required]
        [Range(0, 100, ErrorMessage = "% giảm giá phải nằm trong khoảng 1% đến 100%")]
        public float LecturerSalaryPercentStudent { get; set; }

        public float SalaryAllowance { get; set; }

        public string Note { get; set; }

        public string TeacherID { get; set; }
    }
}
