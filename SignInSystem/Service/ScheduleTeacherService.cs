using Microsoft.EntityFrameworkCore;
using SignInSystem.Context;
using SignInSystem.DTO.ScheduleTeacher;
using SignInSystem.Entity;
using SignInSystem.Interface;
#nullable disable
namespace SignInSystem.Service
{
    public class ScheduleTeacherService : IScheduleTeacherService
    {
        private readonly SignInSystemContext _context;

        public ScheduleTeacherService(SignInSystemContext context)
        {
            _context = context;
        }

        public async Task CreateScheduleTeacher(ScheduleTeacherDTO ScheduleTeacherDTO)
        {
            ScheduleTeacher scheduleTeacher = new ScheduleTeacher();    
            var check = await _context.Teachers.FirstOrDefaultAsync(s => s.TeacherID == ScheduleTeacherDTO.TeacherID);
            if (check == null)
            {
                throw new BadHttpRequestException("TeacherID không tồn tại, vui lòng kiểm tra lại TeacherID!!!!");
            }
            else
            {
                scheduleTeacher.Room = ScheduleTeacherDTO.Room;
                scheduleTeacher.StartDay = ScheduleTeacherDTO.StartDay;
                scheduleTeacher.EndDay = ScheduleTeacherDTO.EndDay;
                scheduleTeacher.SchoolDay = ScheduleTeacherDTO.SchoolDay;
                scheduleTeacher.StartTime = ScheduleTeacherDTO.StartTime;
                scheduleTeacher.EndTime = ScheduleTeacherDTO.EndTime;
                scheduleTeacher.TeacherID = ScheduleTeacherDTO.TeacherID;

                _context.ScheduleTeachers.Add(scheduleTeacher);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteScheduleTeacher(int id)
        {
            var list = _context.ScheduleTeachers.FirstOrDefault(s => s.ScheduleTeacherID == id);

            _context.Remove(list);
            await _context.SaveChangesAsync();
        }

        public async Task EditScheduleTeacher(int id, string teacherID, UpdateScheduleTeacherDTO updateScheduleTeacherDTO)
        {
            var scheduleTeacher = _context.ScheduleTeachers.FirstOrDefault(s => s.ScheduleTeacherID == id && s.TeacherID == teacherID);

            if (scheduleTeacher == null)
            {
                throw new BadHttpRequestException("TeacherID không tồn tại, vui lòng kiểm tra lại TeacherID!!!!");
            }
            else
            {
                scheduleTeacher.Room = updateScheduleTeacherDTO.Room;
                scheduleTeacher.StartDay = updateScheduleTeacherDTO.StartDay;
                scheduleTeacher.EndDay = updateScheduleTeacherDTO.EndDay;
                scheduleTeacher.SchoolDay = updateScheduleTeacherDTO.SchoolDay;
                scheduleTeacher.StartTime = updateScheduleTeacherDTO.StartTime;
                scheduleTeacher.EndTime = updateScheduleTeacherDTO.EndTime;

                _context.ScheduleTeachers.Update(scheduleTeacher);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ScheduleTeacher> FindIDToResult(int id)
        {
            var list = await _context.ScheduleTeachers.FindAsync(id);
            return list;
        }

        public async Task<List<ScheduleTeacher>> GetRoom(string room)
        {
            var list = await _context.ScheduleTeachers.Where(s => s.Room == room).ToListAsync();
            return list;
        }

        public async Task<List<ScheduleTeacher>> GetScheduleTeacherByID(int id)
        {
            var list = await _context.ScheduleTeachers.Where(s => s.ScheduleTeacherID == id).ToListAsync();
            return list;
        }

        public async Task<List<ScheduleTeacher>> GetTeacherID(string teacherID)
        {
            var list = await _context.ScheduleTeachers.Where(s => s.TeacherID == teacherID).ToListAsync();
            return list;
        }
    }
}
