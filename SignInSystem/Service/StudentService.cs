﻿using Microsoft.EntityFrameworkCore;
using SignInSystem.Context;
using SignInSystem.DTO.Student;
using SignInSystem.Entity;
using SignInSystem.Interface;
#nullable disable
namespace SignInSystem.Service
{
    public class StudentService : IStudentService
    {
        private readonly SignInSystemContext _context;

        public StudentService(SignInSystemContext context)
        {
            _context = context;
        }

        public async Task CreateStudenInClass(string id, string classID)
        {
            Tuition tuition = new Tuition();
            var stu = _context.Students.FirstOrDefault(a => a.StudentID.Equals(id));
            var check = _context.Classes.FirstOrDefault(a => a.ClassID.Equals(classID));

            if (stu == null)
            {
                throw new BadHttpRequestException("StudentID không tồn tại, vui lòng kiểm tra lại StudentID!!!!");
            }
            else
            {
                if (check == null)
                {
                    throw new BadHttpRequestException("ClassID không tồn tại, vui lòng kiểm tra lại ClassID!!!!");
                }
                else
                {
                    if (check.StatusClass != 1)
                    {
                        throw new BadHttpRequestException("Lớp học này đã kết thúc, bạn vui lòng đăng ký lớp khác !!!!");
                    }
                    else
                    {
                        tuition.ClassID = classID;
                        tuition.StudentID = id;
                        tuition.TotalPrice = check.Price;
                        tuition.StatusTuition = false;
                        tuition.Note = "Học sinh mới, mới đăng ký và chưa đóng học phí";

                        _context.Tuitions.Add(tuition);
                        await _context.SaveChangesAsync();
                    }            
                }
            }
        }

        public async Task CreateStudent(RegisterStudentDTO registerStudentDTO)
        {
            Student stu = new Student();
            Tuition tuition = new Tuition();

            bool checkEmail = await _context.Students.AnyAsync(stu => stu.Email.Equals(registerStudentDTO.Email));
            if (checkEmail)
            {
                throw new BadHttpRequestException("Email đã được sử dụng, Bạn vui lòng chọn 1 Email khác!!!!");
            }
            else
            {
                //table student
                stu.StudentID = registerStudentDTO.StudentID;
                //stu.StudentName = (registerStudentDTO.LastName.Trim() + " " + registerStudentDTO.FirstName.Trim()).Trim();
                stu.StudentName = string.Join(" ", registerStudentDTO.LastName.Trim(), registerStudentDTO.FirstName.Trim());
                stu.DateOfBirth = registerStudentDTO.DateOfBirth;
                stu.Gender = registerStudentDTO.Gender;
                stu.Email = registerStudentDTO.Email;
                stu.Phone = registerStudentDTO.Phone;
                stu.Address = registerStudentDTO.Address;
                stu.ParentName = registerStudentDTO.ParentName;
                stu.Password = registerStudentDTO.Password;
                stu.Image = registerStudentDTO.Image;
                stu.NewStudent = true;
                stu.RoleID = 4;

                _context.Students.Add(stu);
                await _context.SaveChangesAsync();

                //table tuition
                tuition.ClassID = registerStudentDTO.ClassID;
                tuition.StudentID = registerStudentDTO.StudentID;

                var searchClass = await _context.Classes.FindAsync(registerStudentDTO.ClassID);

                if(searchClass.StatusClass != 1)
                {
                    throw new BadHttpRequestException("Lớp học này đã kết thúc, bạn vui lòng đăng ký lớp khác !!!!");
                }
                else
                {
                    //var searchVoucher = await _context.Students.FindAsync(stu.VoucherID);
                    //var voucher = _context.Vouchers.FirstOrDefault(a => a.VoucherID == stu.VoucherID);

                    tuition.TotalPrice = searchClass.Price;
                    tuition.StatusTuition = false;
                    tuition.Note = "Học sinh mới, mới đăng ký và chưa đóng học phí";

                    _context.Tuitions.Add(tuition);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task DeleteStudent(string id)
        {
            var search = _context.Students.FirstOrDefault(a => a.StudentID.Equals(id));
            var searchTuitions = _context.Tuitions.FirstOrDefault(a => a.StudentID.Equals(id));

            _context.Tuitions.Remove(searchTuitions);
            _context.Students.Remove(search);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentInClass(string id, string classID)
        {
            var search = _context.Tuitions.FirstOrDefault(a => a.StudentID.Equals(id));
            var check = _context.Tuitions.FirstOrDefault(a => a.ClassID.Equals(classID));
            if (search == null || check == null)
            {
                throw new BadHttpRequestException("Học sinh này không có trong lớp " + classID + " , bạn vui lòng kiểm tra lại !!!!");
            }
            else
            {
                _context.Tuitions.Remove(check);
                await _context.SaveChangesAsync();
            }
        }

        public async Task EditStudent(string id, UpdateStudentDTO updateStudentDTO)
        {
            var stu = _context.Students.FirstOrDefault(a => a.StudentID.Equals(id));
            if (stu == null)
            {
                throw new BadHttpRequestException("StudentID không tồn tại, vui lòng kiểm tra lại StudentID!!!!");
            }
            else
            {
                stu.StudentName = updateStudentDTO.LastName + " " + updateStudentDTO.FirstName;
                stu.DateOfBirth = updateStudentDTO.DateOfBirth;
                stu.Gender = updateStudentDTO.Gender;
                stu.Phone = updateStudentDTO.Phone;
                stu.Address = updateStudentDTO.Address;
                stu.ParentName = updateStudentDTO.ParentName;
                stu.Password = updateStudentDTO.Password;
                stu.Image = updateStudentDTO.Image;

                _context.Students.Update(stu);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Class> FindClassID(string id)
        {
            var search = await _context.Classes.FindAsync(id);
            return search;
        }

        public async Task<Student> FindIDToResult(string id)
        {
            var search = await _context.Students.FindAsync(id);
            return search;
        }

        public async Task<List<Student>> GetAll()
        {
            var list = await _context.Students
                .Include(s => s.Voucher)
                .Include(s => s.Tuitions)
                .ToListAsync();
            return list;
        }

        public async Task<List<Student>> GetAllNewStudent()
        {
            var list = await _context.Students
                .Include(s => s.Tuitions)
                .Where(a => a.NewStudent == true)
                .ToListAsync();
            return list;
        }

        public async Task<List<Student>> GetStudentByEmail(string email)
        {
            var list = await _context.Students
                .Include(s => s.Voucher)
                .Include(s => s.Tuitions)
                .Where(a => a.Email.Trim().ToLower().Contains(email.Trim().ToLower())).ToListAsync();
            return list;
        }

        public async Task<List<Student>> GetStudentByID(string id)
        {
            var list = await _context.Students
                .Include(s => s.Voucher)
                .Include(s => s.Tuitions)
                .Where(a => a.StudentID.Equals(id)).ToListAsync();
            return list;
        }

        public async Task<List<Student>> GetStudentByName(string name)
        {
            var list = await _context.Students
                .Include(s => s.Voucher)
                .Include(s => s.Tuitions)
                .Where(a => a.StudentName.Trim().ToLower().Contains(name.Trim().ToLower())).ToListAsync();
            return list;
        }

        public async Task<List<Student>> SearchStudentNameEmailID(string search)
        {
            var list = await _context.Students
                .Include(s => s.Voucher)
                .Include(s => s.Tuitions)
                .Where(a => a.StudentName.Trim().ToLower().Contains(search.Trim().ToLower()) ||
                            a.Email.Trim().ToLower().Contains(search.Trim().ToLower()) ||
                            a.StudentID.Trim().ToLower().Contains(search.Trim().ToLower())).ToListAsync();
            return list;
        }
    }
}
