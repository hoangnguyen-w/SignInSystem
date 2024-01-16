using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
#nullable disable
namespace SignInSystem.Entity
{
    public class Subject
    {
        [Key]
        public int SubjectID { get; set; }

        public string SubjectName { get; set; }

        public TimeSpan Time { get; set; }


        [JsonIgnore]
        public virtual ICollection<Class> Classes { get; set; }

        [JsonIgnore]
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
