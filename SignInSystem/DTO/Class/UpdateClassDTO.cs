#nullable disable
using System.ComponentModel.DataAnnotations;

namespace SignInSystem.DTO.Class
{
    public class UpdateClassDTO
    {
        [Required]
        public string ClassName { get; set; }

        public string Discription { get; set; }

        [Required]
        [Range(1000.0, float.MaxValue, ErrorMessage = "Lỗi nhập, giá phải từ 1000 VND trở lên ")]
        public float Price { get; set; }

        [Required]
        public int SlotStudent { get; set; }

        public int SemesterID { get; set; }
        public int SubjectID { get; set; }
    }
}
