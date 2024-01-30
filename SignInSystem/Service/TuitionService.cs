using Microsoft.EntityFrameworkCore;
using SignInSystem.Context;
using SignInSystem.DTO.Tuition;
using SignInSystem.Entity;
using SignInSystem.Interface;
#nullable disable
namespace SignInSystem.Service
{
    public class TuitionService : ITuitionService
    {
        private readonly SignInSystemContext _context;

        public TuitionService(SignInSystemContext context)
        {
            _context = context;
        }

        public async Task CreateTuition(TuitionDTO tuitionDTO)
        {
            var checkClass = _context.Classes.FirstOrDefault(c => c.ClassID == tuitionDTO.ClassID);
            var checkTuitionType = _context.TuitionTypes.FirstOrDefault(t => t.TuitionTypeID == tuitionDTO.TuitionTypeID);
            var checkStudent = _context.Students.FirstOrDefault(s => s.StudentID == tuitionDTO.StudentID);

            if (checkClass == null)
            {
                throw new BadHttpRequestException("ClassID không tồn tại, vui lòng kiểm tra lại ClassID!!!!");
            }
            else
            {
                if (checkTuitionType == null)
                {
                    throw new BadHttpRequestException("TuitionTypeID không tồn tại, vui lòng kiểm tra lại TuitionTypeID!!!!");
                }
                else
                {
                    if (checkStudent == null)
                    {
                        throw new BadHttpRequestException("StudentID không tồn tại, vui lòng kiểm tra lại StudentID!!!!");
                    }
                    else
                    {
                        Tuition tuition = new Tuition();


                        tuition.ClassID = tuitionDTO.ClassID;
                        tuition.TuitionTypeID = tuitionDTO.TuitionTypeID;
                        tuition.Note = tuitionDTO.Discription + "/n" + "- Chưa thanh toán tiền học phí";
                        tuition.StatusTuition = false;
                        tuition.StudentID = tuitionDTO.StudentID;
                        tuition.TotalPrice = checkClass.Price - tuitionDTO.Discount;

                        _context.Tuitions.Add(tuition);
                        await _context.SaveChangesAsync();

                    }
                }
            }
        }

        public async Task AddVoucherTuition(int id, AddVoucherDTO addVoucherDTO)
        {
            var list = _context.Tuitions.FirstOrDefault(t => t.TuitionID == id);
            var getStudent = _context.Students.FirstOrDefault(t => t.StudentID == list.StudentID);
            var checkVoucher = _context.Vouchers.FirstOrDefault(v => v.VoucherID == addVoucherDTO.VoucherID);
            if (checkVoucher == null)
            {
                throw new BadHttpRequestException("VoucherID không tồn tại, vui lòng kiểm tra lại VoucherID!!!!");
            }
            else
            {
                if (checkVoucher.VoucherID != getStudent.VoucherID)
                {
                    throw new BadHttpRequestException("Voucher '" + checkVoucher.VoucherName + "' không tồn tại, vui lòng kiểm tra lại Voucher!!!!");
                }
                else
                {
                    if (checkVoucher.StatusVoucher == false)
                    {
                        throw new BadHttpRequestException("Voucher '" + checkVoucher.VoucherName + "' đã được sử dụng, vui lòng chọn Voucher khác!!!!");
                    }
                    else
                    {
                        list.TotalPrice = list.TotalPrice - (list.TotalPrice * checkVoucher.PercentDiscount / 100);

                        checkVoucher.StatusVoucher = false;

                        _context.Tuitions.Update(list);
                        _context.Vouchers.Update(checkVoucher);
                        await _context.SaveChangesAsync();
                    }
                }
            }
        }

        public async Task DeleteTuition(int id)
        {
            var list = _context.Tuitions.FirstOrDefault(t => t.TuitionID == id);

            _context.Remove(list);
            await _context.SaveChangesAsync();
        }

        public async Task EditTuition(int id, UpdateTuitionDTO updateTuitionDTO)
        {
            var list = _context.Tuitions.FirstOrDefault(r => r.TuitionID == id);

            if (list.StatusTuition == false || list.StatusTuition == null)
            {
                list.Note = updateTuitionDTO.Note + "/n" + "- Chưa thanh toán tiền học phí";
            }
            else
            {
                list.Note = updateTuitionDTO.Note + "/n" + "- Đã thanh toán tiền học phí "; ;
            }

            _context.Tuitions.Update(list);
            await _context.SaveChangesAsync();
        }

        public async Task ChangStautsTuition(int id)
        {
            var list = _context.Tuitions.SingleOrDefault(r => r.TuitionID == id);

            if (list.StatusTuition == true)
            {
                throw new BadHttpRequestException("Học Sinh này đã thu tiền rồi!!!!");
            }
            else
            {
                list.StatusTuition = true;

                // Tách chuỗi theo ký tự "/n" và lấy phần trước
                string[] noteParts = list.Note.Split(new string[] { "/n" }, StringSplitOptions.None);
                string partBefore = noteParts[0];

                // Thêm vào phía trước
                list.Note = partBefore + "/n" + "- Đã thanh toán tiền học phí ";

                _context.Tuitions.Update(list);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Tuition>> GetPayTution()
        {
            var list = await _context.Tuitions
                .Include(t => t.Student)
                .Where(t => t.StatusTuition == true).ToListAsync();
            return list;
        }

        public async Task<Tuition> FindIDToResult(int id)
        {
            var list = await _context.Tuitions.FindAsync(id);
            return list;
        }

        public async Task<List<Tuition>> GetAll()
        {
            var list = await _context.Tuitions
                .ToListAsync();
            return list;
        }

        public async Task<List<Tuition>> GetTuitionByID(int id)
        {
            var list = await _context.Tuitions.Where(t => t.TuitionID == id).ToListAsync();
            return list;
        }
    }
}
