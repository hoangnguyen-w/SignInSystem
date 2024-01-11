﻿using Microsoft.EntityFrameworkCore;
using SignInSystem.Entity;
#nullable disable
namespace SignInSystem.Context
{
    public class SignInSystemContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Class> Classes { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Score> Scores { get; set; }

        public DbSet<ScoreType> ScoreTypes { get; set; }

        public DbSet<Semester> Semesters { get; set; }

        public DbSet<Student> Students { get;set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Tuition> Tuitions { get; set; }

        public DbSet<TuitionType> TuitionTypes { get; set; }

        public DbSet<Voucher> Vouchers { get; set; }

        public SignInSystemContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Hàm này để ép dữ liệu mặc định
            this.SeedRoles(modelBuilder);
            this.SeedSubject(modelBuilder);
            this.SeedAccount(modelBuilder);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(new Role()
            {
                RoleID = 1,
                RoleName = "Admin"
            });
            builder.Entity<Role>().HasData(new Role()
            {
                RoleID = 2,
                RoleName = "Staff"
            });
            builder.Entity<Role>().HasData(new Role()
            {
                RoleID = 3,
                RoleName = "Teacher"
            });
            builder.Entity<Role>().HasData(new Role()
            {
                RoleID = 4,
                RoleName = "Student"
            });
        }

        private void SeedAccount(ModelBuilder builder)
        {
            builder.Entity<Account>().HasData(new Account()
            {
                AccountID = 1,
                Email = "Admin",
                Password = "123",
                RoleID = 1
            });
        }
        private void SeedSubject(ModelBuilder builder)
        {
            builder.Entity<Subject>().HasData(new Subject()
            {
                SubjectID = 1,
                SubjectName = "Cờ Tướng - Cờ Vua",
                Time = TimeSpan.FromMinutes(90)
            });
            builder.Entity<Subject>().HasData(new Subject()
            {
                SubjectID = 2,
                SubjectName = "Đàn Piano",
                Time = TimeSpan.FromMinutes(90)
            });
            builder.Entity<Subject>().HasData(new Subject()
            {
                SubjectID = 3,
                SubjectName = "Cầu lông",
                Time = TimeSpan.FromMinutes(90)
            });
            builder.Entity<Subject>().HasData(new Subject()
            {
                SubjectID = 4,
                SubjectName = "Bơi lội",
                Time = TimeSpan.FromMinutes(90)
            });
            builder.Entity<Subject>().HasData(new Subject()
            {
                SubjectID = 5,
                SubjectName = "Tiếng Anh",
                Time = TimeSpan.FromMinutes(90)
            });
            builder.Entity<Subject>().HasData(new Subject()
            {
                SubjectID = 6,
                SubjectName = "Công Nghệ Thông Tin",
                Time = TimeSpan.FromMinutes(90)
            });
            builder.Entity<Subject>().HasData(new Subject()
            {
                SubjectID = 7,
                SubjectName = "Tiếng Nhật",
                Time = TimeSpan.FromMinutes(90)
            });
            builder.Entity<Subject>().HasData(new Subject()
            {
                SubjectID = 8,
                SubjectName = "Âm Nhạc",
                Time = TimeSpan.FromMinutes(90)
            });
        }
    }
}
