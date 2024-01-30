#nullable disable
using System.ComponentModel.DataAnnotations;

namespace SignInSystem.DTO.Voucher
{
    public class VoucherDTO
    {
        public string VoucherName { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "% giảm giá phải nằm trong khoảng 1% đến 100%")]
        public int PercentDiscount { get; set; }
    }
}
