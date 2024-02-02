using System.ComponentModel.DataAnnotations;
#nullable disable
namespace SignInSystem.Entity
{
    public class Holiday
    {
        [Key]
        public int HolidayID { get; set; }

        [Required]
        public string HolidayName { get; set; }

        public string HolidayReason { get; set; }   

        public DateTime? HolidayDateStart { get; set; }

        public DateTime? HolidayDateEnd { get; set; }
    }
}
