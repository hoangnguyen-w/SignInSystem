using SignInSystem.DTO.Voucher;
using SignInSystem.Entity;

namespace SignInSystem.Interface
{
    public interface IVoucherService
    {
        Task<List<Voucher>> GetAll();

        Task<List<Voucher>> GetVoucherByID(int id);

        Task<List<Voucher>> GetVoucherByName(string voucherName);

        Task<Voucher> FindIDToResult(int id);

        Task CreateVoucher(VoucherDTO voucherDTO);

        Task EditVoucher(int id, VoucherDTO voucherDTO);

        Task DeleteVoucher(int id);
    }
}
