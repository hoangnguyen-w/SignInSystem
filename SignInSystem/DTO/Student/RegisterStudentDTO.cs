#nullable disable
using SignInSystem;
using System.ComponentModel.DataAnnotations;

namespace SignInSystem.DTO.Student
{
    public class RegisterStudentDTO
    {
        [Required]
        public string StudentID { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]  
        public string Email { get; set; }

        [MaxLength(20)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Input your Number")]
        public string? Phone { get; set; }

        public string Address { get; set; }

        public string ParentName { get; set; }
        [Required]
        public string Password { get; set; }

        public string Image { get; set; }
        [Required]
        public string ClassID { get; set; }
    }
}
