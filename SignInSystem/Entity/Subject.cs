using System.ComponentModel.DataAnnotations;
#nullable disable
namespace SignInSystem.Entity
{
    public class Subject
    {
        [Key]
        public int SubjectID { get; set; }

        public string SubjectName { get; set; }

        public TimeSpan Time { get; set; }
    }
}
