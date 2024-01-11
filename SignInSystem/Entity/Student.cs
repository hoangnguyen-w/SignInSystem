using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable
namespace SignInSystem.Entity
{
    public class Student
    {
        [Key]
        public string StudentID { get; set; }

        public string StudentName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]

        public string Password { get; set; }

        public string ParentName { get; set; }

        public string Address { get; set; }

        public DateTime DateOfBirth { get; set; }

        [MaxLength(20)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Input your Number")]
        public string Phone { get; set; }

        public string Image { get; set; }

        public string Gender { get; set; }


        //Khóa ngoại
        [ForeignKey("Voucher")]
        public int VoucherID { get; set; }
        public virtual Voucher Voucher { get; set; }

        [ForeignKey("Role")]
        public int RoleID { get; set; }
        public virtual Role Role { get; set; }
    }
}
