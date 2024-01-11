#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SignInSystem.Entity
{
    public class Class
    {
        [Key]
        public string ClassID { get; set; }  

        [Required]
        public string ClassName { get; set; }

        public string Discription { get; set; }

        [Required]
        [Range(1000.0, float.MaxValue, ErrorMessage = "Lỗi nhập, giá phải từ 1000 VND trở lên ")]
        public float Price { get; set; }

        [Required]
        public int SlotStudent { get; set; }

        public int StatusClass { get; set; }


        //KHóa ngoại
        [ForeignKey("Semester")]
        public int SemesterID { get; set; }
        public virtual Semester Semester { get; set; }


        [ForeignKey("Subject")]
        public int SubjectID { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
