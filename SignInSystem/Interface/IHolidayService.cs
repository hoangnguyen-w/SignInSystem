using SignInSystem.DTO.Holiday;
using SignInSystem.Entity;

namespace SignInSystem.Interface
{
    public interface IHolidayService
    {
        Task<List<Holiday>> GetAll();

        Task<List<Holiday>> GetHolidayByID(int id);

        Task<List<Holiday>> GetHolidayByName(string holidayName);

        Task<Holiday> FindIDToResult(int id);

        Task CreateHoliday(HolidayDTO holidayDTO);

        Task EditHoliday(int id, HolidayDTO holidayDTO);

        Task DeleteHoliday(int id);
    }
}
