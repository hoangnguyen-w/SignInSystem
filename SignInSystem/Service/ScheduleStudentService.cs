using Microsoft.EntityFrameworkCore;
using SignInSystem.Context;
using SignInSystem.DTO.ScheduleStudent;
using SignInSystem.Entity;
using SignInSystem.Interface;
#nullable disable
namespace SignInSystem.Service
{
    public class ScheduleStudentService : IScheduleStudentService
    {
        private readonly SignInSystemContext _context;

        public ScheduleStudentService(SignInSystemContext context)
        {
            _context = context;
        }

        public async Task CreateScheduleStudent(ScheduleStudentDTO scheduleStudentDTO)
        {
            ScheduleStudent scheduleStudent = new ScheduleStudent();
            var check = await _context.Students.FirstOrDefaultAsync(s => s.StudentID == scheduleStudentDTO.StudentID);
            if (check == null)
            {
                throw new BadHttpRequestException("StudentID không tồn tại, vui lòng kiểm tra lại StudentID!!!!");
            }
            else
            {
                scheduleStudent.Room = scheduleStudentDTO.Room;
                scheduleStudent.StartDay = scheduleStudentDTO.StartDay;
                scheduleStudent.EndDay = scheduleStudentDTO.EndDay;
                scheduleStudent.SchoolDay = scheduleStudentDTO.SchoolDay;
                scheduleStudent.StartTime = scheduleStudentDTO.StartTime;
                scheduleStudent.EndTime = scheduleStudentDTO.EndTime;
                scheduleStudent.StudentID = scheduleStudentDTO.StudentID;

                _context.ScheduleStudents.Add(scheduleStudent);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteScheduleStudent(int id)
        {
            var list = _context.ScheduleStudents.FirstOrDefault(s => s.ScheduleStudentID == id);

            _context.Remove(list);
            await _context.SaveChangesAsync();
        }

        public async Task EditScheduleStudent(int id, string studentID, UpdateScheduleStudentDTO updateScheduleStudentDTO)
        {
            var scheduleStudent = _context.ScheduleStudents.FirstOrDefault(s => s.ScheduleStudentID == id && s.StudentID == studentID);

            if (scheduleStudent == null)
            {
                throw new BadHttpRequestException("StudentID không tồn tại, vui lòng kiểm tra lại StudentID!!!!");
            }
            else
            {
                scheduleStudent.Room = updateScheduleStudentDTO.Room;
                scheduleStudent.StartDay = updateScheduleStudentDTO.StartDay;
                scheduleStudent.EndDay = updateScheduleStudentDTO.EndDay;
                scheduleStudent.SchoolDay = updateScheduleStudentDTO.SchoolDay;
                scheduleStudent.StartTime = updateScheduleStudentDTO.StartTime;
                scheduleStudent.EndTime = updateScheduleStudentDTO.EndTime;

                _context.ScheduleStudents.Update(scheduleStudent);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ScheduleStudent> FindIDToResult(int id)
        {
            var list = await _context.ScheduleStudents.FindAsync(id);
            return list;
        }

        public async Task<List<ScheduleStudent>> GetRoom(string room)
        {
            var list = await _context.ScheduleStudents.Where(s => s.Room == room).ToListAsync();
            return list;
        }

        public async Task<List<ScheduleStudent>> GetStudentID(string studentID)
        {
            var list = await _context.ScheduleStudents.Where(s => s.StudentID == studentID).ToListAsync();
            return list;
        }

        public async Task<List<ScheduleStudent>> GetScheduleStudentByID(int id)
        {
            var list = await _context.ScheduleStudents.Where(s => s.ScheduleStudentID == id).ToListAsync();
            return list;
        }
    }
}
