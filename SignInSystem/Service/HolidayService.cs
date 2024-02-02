using Microsoft.EntityFrameworkCore;
using SignInSystem.Context;
using SignInSystem.DTO.Holiday;
using SignInSystem.Entity;
using SignInSystem.Interface;
#nullable disable
namespace SignInSystem.Service
{
    public class HolidayService : IHolidayService
    {
        private readonly SignInSystemContext _context;

        public HolidayService(SignInSystemContext context)
        {
            _context = context;
        }

        public async Task CreateHoliday(HolidayDTO holidayDTO)
        {
            Holiday holiday = new Holiday();
            holiday.HolidayName = holidayDTO.HolidayName;
            holiday.HolidayReason = holidayDTO.HolidayReason;
            holiday.HolidayDateStart = holidayDTO.HolidayDateStart;
            holiday.HolidayDateEnd = holidayDTO.HolidayDateEnd;

            _context.Holidays.Add(holiday);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHoliday(int id)
        {
            var list = _context.Holidays.FirstOrDefault(h => h.HolidayID == id);

            _context.Remove(list);
            await _context.SaveChangesAsync();
        }

        public async Task EditHoliday(int id, HolidayDTO holidayDTO)
        {
            var holiday = _context.Holidays.FirstOrDefault(h => h.HolidayID == id);

            holiday.HolidayName = holidayDTO.HolidayName;
            holiday.HolidayReason = holidayDTO.HolidayReason;
            holiday.HolidayDateStart = holidayDTO.HolidayDateStart;
            holiday.HolidayDateEnd = holidayDTO.HolidayDateEnd;

            _context.Holidays.Update(holiday);
            await _context.SaveChangesAsync();
        }

        public async Task<Holiday> FindIDToResult(int id)
        {
            var list = await _context.Holidays.FindAsync(id);
            return list;
        }

        public async Task<List<Holiday>> GetAll()
        {
            var list = await _context.Holidays.ToListAsync();
            return list;
        }

        public async Task<List<Holiday>> GetHolidayByID(int id)
        {
            var list = await _context.Holidays.Where(h => h.HolidayID == id).ToListAsync();
            return list;
        }

        public async Task<List<Holiday>> GetHolidayByName(string holidayName)
        {
            var list = await _context.Holidays.Where(r => r.HolidayName.Trim().ToLower().Contains(holidayName.Trim().ToLower())).ToListAsync();
            return list;
        }
    }
}
