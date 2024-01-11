using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable
namespace SignInSystem.Entity
{
    public class Score
    {
        [Key]
        public int ScoreID { get; set; }

        [Required]
        [Range(0.0, 10.0, ErrorMessage = "Lỗi nhập điểm, điểm phải từ 1 đến 10")]
        public float ScoreMark { get; set; }

        //Khóa ngoại
        [ForeignKey("Student")]
        public string StudentID { get; set; }
        public virtual Student Student { get; set; }

        [ForeignKey("ScoreType")]
        public int ScoreTypeID { get; set; }
        public virtual ScoreType ScoreType { get; set; }
    }
}
