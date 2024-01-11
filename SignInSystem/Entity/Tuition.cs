using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable
namespace SignInSystem.Entity
{
    public class Tuition
    {
        [Key]
        public int TuitionID { get; set; }

        public float TotalPrice { get; set; }

        public int StatusTuition { get; set; }

        public string Note { get; set; }



        //Khóa ngoại
        [ForeignKey("TuitionType")]
        public int TuitionTypeID { get; set; }
        public virtual TuitionType TuitionType { get; set; }

        [ForeignKey("Class")]
        public string ClassID { get; set; }
        public virtual Class Class { get; set; }

        [ForeignKey("Student")]
        public string StudentID { get; set; }
        public virtual Student Student { get; set; }
    }
}
