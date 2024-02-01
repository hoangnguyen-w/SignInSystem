using System.ComponentModel.DataAnnotations;
#nullable disable
namespace SignInSystem.DTO.Score
{
    public class ScoreDTO
    {
        [Required]
        [Range(0.0, 10.0, ErrorMessage = "Lỗi nhập điểm, điểm phải từ 1 đến 10")]
        public float ScoreMark { get; set; }

        public string StudentID { get; set; }

        public int ScoreTypeID { get; set; }

        public int SubjectID { get; set; }
    }
}
