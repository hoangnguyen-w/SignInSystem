using System.ComponentModel.DataAnnotations;
#nullable disable
namespace SignInSystem.Entity
{
    public class Semester
    {
        [Key]
        public int SemesterID { get; set; }

        public string SemesterName { get; set; }
    }
}
