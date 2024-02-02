using SignInSystem.DTO.ScheduleTeacher;
using SignInSystem.Entity;

namespace SignInSystem.Interface
{
    public interface IScheduleTeacherService
    {
        Task<List<ScheduleTeacher>> GetRoom(string room);

        Task<List<ScheduleTeacher>> GetTeacherID(string teacherID);

        Task<List<ScheduleTeacher>> GetScheduleTeacherByID(int id);

        Task<ScheduleTeacher> FindIDToResult(int id);

        Task CreateScheduleTeacher(ScheduleTeacherDTO ScheduleTeacherDTO);

        Task EditScheduleTeacher(int id, string teacherID, UpdateScheduleTeacherDTO updateScheduleTeacherDTO);

        Task DeleteScheduleTeacher(int id);
    }
}
