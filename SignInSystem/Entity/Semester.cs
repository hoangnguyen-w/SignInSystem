using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
#nullable disable
namespace SignInSystem.Entity
{
    public class Semester
    {
        [Key]
        public int SemesterID { get; set; }

        public string SemesterName { get; set; }


        [JsonIgnore]
        public virtual ICollection<Class> Classes { get; set; }
    }
}
