using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
#nullable disable
namespace SignInSystem.Entity
{
    public class Voucher
    {
        [Key]
        public int VoucherID { get; set; }

        public string VoucherName { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "% giảm giá phải nằm trong khoảng 1% đến 100%")]
        public int PercentDiscount { get; set; }

        public bool StatusVoucher { get; set; }


        [JsonIgnore]
        public virtual ICollection<Student> Students { get; set; }
    }
}
