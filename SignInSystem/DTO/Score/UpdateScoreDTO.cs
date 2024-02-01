using System.ComponentModel.DataAnnotations;
#nullable disable
namespace SignInSystem.DTO.Score
{
    public class UpdateScoreDTO
    {
        [Required]
        [Range(0.0, 10.0, ErrorMessage = "Lỗi nhập điểm, điểm phải từ 1 đến 10")]
        public float ScoreMark { get; set; }
    }
}
