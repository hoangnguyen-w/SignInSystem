using System.ComponentModel.DataAnnotations;
#nullable disable
namespace SignInSystem.Entity
{
    public class Voucher
    {
        [Key]
        public int VoucherID { get; set; }

        public string VoucherName { get; set; }

        public int PercentDiscount { get; set; }

    }
}
