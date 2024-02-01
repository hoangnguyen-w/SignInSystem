#nullable disable
namespace SignInSystem.DTO.ScheduleStudent
{
    public class ScheduleStudentDTO
    {
        public string Room { get; set; }

        public DateTime? StartDay { get; set; }

        public DateTime? EndDay { get; set; }

        public string SchoolDay { get; set; }

        public TimeSpan? StartTime { get; set; }

        public TimeSpan? EndTime { get; set; }

        public string StudentID { get; set; }
    }
}
