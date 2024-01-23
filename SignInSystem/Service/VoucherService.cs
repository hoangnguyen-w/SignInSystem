using Microsoft.EntityFrameworkCore;
using SignInSystem.Context;
using SignInSystem.DTO.Voucher;
using SignInSystem.Entity;
using SignInSystem.Interface;
#nullable disable
namespace SignInSystem.Service
{
    public class VoucherService : IVoucherService
    {
        private readonly SignInSystemContext _context;

        public VoucherService(SignInSystemContext context)
        {
            _context = context;
        }

        public async Task CreateVoucher(VoucherDTO voucherDTO)
        {
            Voucher voucher = new Voucher();
            voucher.VoucherName = voucherDTO.VoucherName;
            voucher.PercentDiscount = voucherDTO.PercentDiscount;

            _context.Vouchers.Add(voucher);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVoucher(int id)
        {
            var list = _context.Vouchers.FirstOrDefault(v => v.VoucherID == id);

            _context.Remove(list);
            await _context.SaveChangesAsync();
        }

        public async Task EditVoucher(int id, VoucherDTO voucherDTO)
        {
            var list = _context.Vouchers.FirstOrDefault(v => v.VoucherID == id);

            list.VoucherName = voucherDTO.VoucherName;
            list.PercentDiscount = voucherDTO.PercentDiscount;

            _context.Vouchers.Update(list);
            await _context.SaveChangesAsync();
        }

        public async Task<Voucher> FindIDToResult(int id)
        {
            var list = await _context.Vouchers.FindAsync(id);
            return list;
        }

        public async Task<List<Voucher>> GetAll()
        {
            var list = await _context.Vouchers.ToListAsync();
            return list;
        }

        public async Task<List<Voucher>> GetVoucherByID(int id)
        {
            var list = await _context.Vouchers.Where(v => v.VoucherID == id).ToListAsync();
            return list;
        }

        public async Task<List<Voucher>> GetVoucherByName(string voucherName)
        {
            var list = await _context.Vouchers.Where(v => v.VoucherName.Trim().ToLower().Contains(voucherName.Trim().ToLower())).ToListAsync();
            return list;
        }
    }
}
