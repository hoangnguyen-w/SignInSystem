using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
#nullable disable
namespace SignInSystem.Entity
{
    public class Tuition
    {
        [Key]
        public int TuitionID { get; set; }

        public float? TotalPrice { get; set; }

        public bool? StatusTuition { get; set; }

        public string? Note { get; set; }



        //Khóa ngoại
        [ForeignKey("TuitionType")]
        public int? TuitionTypeID { get; set; }
        [JsonIgnore]
        public virtual TuitionType TuitionType { get; set; }

        [ForeignKey("Class")]
        public string ClassID { get; set; }
        [JsonIgnore]
        public virtual Class Class { get; set; }

        [ForeignKey("Student")]
        public string StudentID { get; set; }
        [JsonIgnore]
        public virtual Student Student { get; set; }
    }
}
