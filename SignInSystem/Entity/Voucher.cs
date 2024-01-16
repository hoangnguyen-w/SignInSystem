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

        public int PercentDiscount { get; set; }


        [JsonIgnore]
        public virtual ICollection<Student> Students { get; set; }
    }
}
