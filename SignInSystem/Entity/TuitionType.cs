using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
#nullable disable
namespace SignInSystem.Entity
{
    public class TuitionType
    {
        [Key]
        public int TuitionTypeID { get; set; }

        public string TuitionTypeName { get; set; }


        [JsonIgnore]
        public virtual ICollection<Tuition> Tuitions { get; set; }
    }
}
