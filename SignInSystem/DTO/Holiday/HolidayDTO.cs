#nullable disable
namespace SignInSystem.DTO.Holiday
{
    public class HolidayDTO
    {
        public string HolidayName { get; set; }

        public string HolidayReason { get; set; }

        public DateTime? HolidayDateStart { get; set; }

        public DateTime? HolidayDateEnd { get; set; }
    }
}
