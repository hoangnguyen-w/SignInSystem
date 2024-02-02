using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
#nullable disable
namespace SignInSystem.Entity
{
    public class Teacher
    {
        [Key]
        public string TeacherID { get; set; }

        public string TeacherName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string TaxCode { get; set; }

        public string Address { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [MaxLength(20)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Input your Number")]
        public string Phone { get; set; }

        public string Image { get; set; }



        //Khóa ngoại
        [ForeignKey("Subject")]
        public int SubjectID { get; set; }
        public virtual Subject Subject { get; set; }

        [ForeignKey("Role")]
        public int RoleID { get; set; }
        public virtual Role Role { get; set; }


        [JsonIgnore]
        public virtual ICollection<ScheduleTeacher> Schedules { get; set; }

        [JsonIgnore]
        public virtual ICollection<Teacher> Teachers { get; set; }


        //JWT authentication
        public string RefreshToken { get; set; }
        public DateTime? TokenCreated { get; set; }
        public DateTime? TokenExpires { get; set; }
    }
}
