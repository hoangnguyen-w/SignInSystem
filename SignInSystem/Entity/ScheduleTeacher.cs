using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable
namespace SignInSystem.Entity
{
    public class ScheduleTeacher
    {
        [Key]
        public int ScheduleTeacherID { get; set; }

        public string Room { get; set; }

        public DateTime? StartDay { get; set; }

        public DateTime? EndDay { get; set; }

        public string SchoolDay { get; set; }

        public TimeSpan? StartTime { get; set; }

        public TimeSpan? EndTime { get; set; }


        //KHóa ngoại
        [ForeignKey("Teacher")]
        public string TeacherID { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
