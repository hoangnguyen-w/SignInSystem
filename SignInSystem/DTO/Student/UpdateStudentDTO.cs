#nullable disable
using System.ComponentModel.DataAnnotations;

namespace SignInSystem.DTO.Student
{
    public class UpdateStudentDTO
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Gender { get; set; }

        [MaxLength(20)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Input your Number")]
        public string Phone { get; set; }

        public string Address { get; set; }

        public string ParentName { get; set; }

        public string Password { get; set; }

        public string Image { get; set; }
    }
}
