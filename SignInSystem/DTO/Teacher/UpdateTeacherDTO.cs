using System.ComponentModel.DataAnnotations;
#nullable disable
namespace SignInSystem.DTO.Teacher
{
    public class UpdateTeacherDTO
    {
        public string TeacherName { get; set; }

        [Required]
        public string Password { get; set; }

        public string TaxCode { get; set; }

        public string Address { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [MaxLength(20)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Input your Number")]
        public string Phone { get; set; }

        public string Image { get; set; }
        [Required]
        public int SubjectID { get; set; }
    }
}
