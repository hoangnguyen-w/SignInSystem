using SignInSystem.DTO.ScheduleStudent;
using SignInSystem.Entity;

namespace SignInSystem.Interface
{
    public interface IScheduleStudentService
    {
        Task<List<ScheduleStudent>> GetRoom(string room);

        Task<List<ScheduleStudent>> GetStudentID(string studentID);

        Task<List<ScheduleStudent>> GetScheduleStudentByID(int id);

        Task<ScheduleStudent> FindIDToResult(int id);

        Task CreateScheduleStudent(ScheduleStudentDTO scheduleStudentDTO);

        Task EditScheduleStudent(int id, string studentID, UpdateScheduleStudentDTO updateScheduleStudentDTO);

        Task DeleteScheduleStudent(int id);
    }
}
