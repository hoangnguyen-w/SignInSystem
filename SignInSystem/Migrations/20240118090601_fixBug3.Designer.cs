﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SignInSystem.Context;

#nullable disable

namespace SignInSystem.Migrations
{
    [DbContext(typeof(SignInSystemContext))]
    [Migration("20240118090601_fixBug3")]
    partial class fixBug3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SignInSystem.Entity.Account", b =>
                {
                    b.Property<int>("AccountID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountID"), 1L, 1);

                    b.Property<string>("AccountName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TokenCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("TokenExpires")
                        .HasColumnType("datetime2");

                    b.HasKey("AccountID");

                    b.HasIndex("RoleID");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            AccountID = 1,
                            Email = "Admin",
                            Password = "123",
                            RoleID = 1
                        });
                });

            modelBuilder.Entity("SignInSystem.Entity.Class", b =>
                {
                    b.Property<string>("ClassID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("SemesterID")
                        .HasColumnType("int");

                    b.Property<int>("SlotStudent")
                        .HasColumnType("int");

                    b.Property<int>("StatusClass")
                        .HasColumnType("int");

                    b.Property<int>("SubjectID")
                        .HasColumnType("int");

                    b.HasKey("ClassID");

                    b.HasIndex("SemesterID");

                    b.HasIndex("SubjectID");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("SignInSystem.Entity.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleID"), 1L, 1);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleID = 1,
                            RoleName = "Admin"
                        },
                        new
                        {
                            RoleID = 2,
                            RoleName = "Staff"
                        },
                        new
                        {
                            RoleID = 3,
                            RoleName = "Teacher"
                        },
                        new
                        {
                            RoleID = 4,
                            RoleName = "Student"
                        });
                });

            modelBuilder.Entity("SignInSystem.Entity.Schedule", b =>
                {
                    b.Property<int>("ScheduleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScheduleID"), 1L, 1);

                    b.Property<DateTime>("EndDay")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<string>("Room")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolDay")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDay")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.Property<string>("TeacherID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ScheduleID");

                    b.HasIndex("TeacherID");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("SignInSystem.Entity.Score", b =>
                {
                    b.Property<int>("ScoreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScoreID"), 1L, 1);

                    b.Property<float>("ScoreMark")
                        .HasColumnType("real");

                    b.Property<int>("ScoreTypeID")
                        .HasColumnType("int");

                    b.Property<string>("StudentID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ScoreID");

                    b.HasIndex("ScoreTypeID");

                    b.HasIndex("StudentID");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("SignInSystem.Entity.ScoreType", b =>
                {
                    b.Property<int>("ScoreTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScoreTypeID"), 1L, 1);

                    b.Property<int>("Coefficient")
                        .HasColumnType("int");

                    b.Property<string>("ScoreTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ScoreTypeID");

                    b.ToTable("ScoreTypes");
                });

            modelBuilder.Entity("SignInSystem.Entity.Semester", b =>
                {
                    b.Property<int>("SemesterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SemesterID"), 1L, 1);

                    b.Property<string>("SemesterName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SemesterID");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("SignInSystem.Entity.Student", b =>
                {
                    b.Property<string>("StudentID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("NewStudent")
                        .HasColumnType("bit");

                    b.Property<string>("ParentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<string>("StudentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TokenCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("TokenExpires")
                        .HasColumnType("datetime2");

                    b.Property<int?>("VoucherID")
                        .HasColumnType("int");

                    b.HasKey("StudentID");

                    b.HasIndex("RoleID");

                    b.HasIndex("VoucherID");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentID = "STU-01",
                            Email = "student",
                            NewStudent = false,
                            Password = "123",
                            RoleID = 4,
                            StudentName = "Test Student"
                        });
                });

            modelBuilder.Entity("SignInSystem.Entity.Subject", b =>
                {
                    b.Property<int>("SubjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectID"), 1L, 1);

                    b.Property<string>("SubjectName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("time");

                    b.HasKey("SubjectID");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            SubjectID = 1,
                            SubjectName = "Cờ Tướng - Cờ Vua",
                            Time = new TimeSpan(0, 1, 30, 0, 0)
                        },
                        new
                        {
                            SubjectID = 2,
                            SubjectName = "Đàn Piano",
                            Time = new TimeSpan(0, 1, 30, 0, 0)
                        },
                        new
                        {
                            SubjectID = 3,
                            SubjectName = "Cầu lông",
                            Time = new TimeSpan(0, 1, 30, 0, 0)
                        },
                        new
                        {
                            SubjectID = 4,
                            SubjectName = "Bơi lội",
                            Time = new TimeSpan(0, 1, 30, 0, 0)
                        },
                        new
                        {
                            SubjectID = 5,
                            SubjectName = "Tiếng Anh",
                            Time = new TimeSpan(0, 1, 30, 0, 0)
                        },
                        new
                        {
                            SubjectID = 6,
                            SubjectName = "Công Nghệ Thông Tin",
                            Time = new TimeSpan(0, 1, 30, 0, 0)
                        },
                        new
                        {
                            SubjectID = 7,
                            SubjectName = "Tiếng Nhật",
                            Time = new TimeSpan(0, 1, 30, 0, 0)
                        },
                        new
                        {
                            SubjectID = 8,
                            SubjectName = "Âm Nhạc",
                            Time = new TimeSpan(0, 1, 30, 0, 0)
                        });
                });

            modelBuilder.Entity("SignInSystem.Entity.Teacher", b =>
                {
                    b.Property<string>("TeacherID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<int>("SubjectID")
                        .HasColumnType("int");

                    b.Property<string>("TaxCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TokenCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("TokenExpires")
                        .HasColumnType("datetime2");

                    b.HasKey("TeacherID");

                    b.HasIndex("RoleID");

                    b.HasIndex("SubjectID");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            TeacherID = "TEA-01",
                            Email = "teacher",
                            Password = "123",
                            RoleID = 3,
                            SubjectID = 2,
                            TaxCode = "VND-TEA-01",
                            TeacherName = "Test Teacher"
                        });
                });

            modelBuilder.Entity("SignInSystem.Entity.Tuition", b =>
                {
                    b.Property<int>("TuitionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TuitionID"), 1L, 1);

                    b.Property<string>("ClassID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("StatusTuition")
                        .HasColumnType("bit");

                    b.Property<string>("StudentID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float?>("TotalPrice")
                        .HasColumnType("real");

                    b.Property<int?>("TuitionTypeID")
                        .HasColumnType("int");

                    b.HasKey("TuitionID");

                    b.HasIndex("ClassID");

                    b.HasIndex("StudentID");

                    b.HasIndex("TuitionTypeID");

                    b.ToTable("Tuitions");
                });

            modelBuilder.Entity("SignInSystem.Entity.TuitionType", b =>
                {
                    b.Property<int>("TuitionTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TuitionTypeID"), 1L, 1);

                    b.Property<string>("TuitionTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TuitionTypeID");

                    b.ToTable("TuitionTypes");
                });

            modelBuilder.Entity("SignInSystem.Entity.Voucher", b =>
                {
                    b.Property<int>("VoucherID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VoucherID"), 1L, 1);

                    b.Property<int>("PercentDiscount")
                        .HasColumnType("int");

                    b.Property<string>("VoucherName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VoucherID");

                    b.ToTable("Vouchers");
                });

            modelBuilder.Entity("SignInSystem.Entity.Account", b =>
                {
                    b.HasOne("SignInSystem.Entity.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("SignInSystem.Entity.Class", b =>
                {
                    b.HasOne("SignInSystem.Entity.Semester", "Semester")
                        .WithMany("Classes")
                        .HasForeignKey("SemesterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SignInSystem.Entity.Subject", "Subject")
                        .WithMany("Classes")
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Semester");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("SignInSystem.Entity.Schedule", b =>
                {
                    b.HasOne("SignInSystem.Entity.Teacher", "Teacher")
                        .WithMany("Schedules")
                        .HasForeignKey("TeacherID");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("SignInSystem.Entity.Score", b =>
                {
                    b.HasOne("SignInSystem.Entity.ScoreType", "ScoreType")
                        .WithMany("Scores")
                        .HasForeignKey("ScoreTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SignInSystem.Entity.Student", "Student")
                        .WithMany("Scores")
                        .HasForeignKey("StudentID");

                    b.Navigation("ScoreType");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SignInSystem.Entity.Student", b =>
                {
                    b.HasOne("SignInSystem.Entity.Role", "Role")
                        .WithMany("Students")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SignInSystem.Entity.Voucher", "Voucher")
                        .WithMany("Students")
                        .HasForeignKey("VoucherID");

                    b.Navigation("Role");

                    b.Navigation("Voucher");
                });

            modelBuilder.Entity("SignInSystem.Entity.Teacher", b =>
                {
                    b.HasOne("SignInSystem.Entity.Role", "Role")
                        .WithMany("Teachers")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SignInSystem.Entity.Subject", "Subject")
                        .WithMany("Teachers")
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("SignInSystem.Entity.Tuition", b =>
                {
                    b.HasOne("SignInSystem.Entity.Class", "Class")
                        .WithMany("Tuitions")
                        .HasForeignKey("ClassID");

                    b.HasOne("SignInSystem.Entity.Student", "Student")
                        .WithMany("Tuitions")
                        .HasForeignKey("StudentID");

                    b.HasOne("SignInSystem.Entity.TuitionType", "TuitionType")
                        .WithMany("Tuitions")
                        .HasForeignKey("TuitionTypeID");

                    b.Navigation("Class");

                    b.Navigation("Student");

                    b.Navigation("TuitionType");
                });

            modelBuilder.Entity("SignInSystem.Entity.Class", b =>
                {
                    b.Navigation("Tuitions");
                });

            modelBuilder.Entity("SignInSystem.Entity.Role", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Students");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("SignInSystem.Entity.ScoreType", b =>
                {
                    b.Navigation("Scores");
                });

            modelBuilder.Entity("SignInSystem.Entity.Semester", b =>
                {
                    b.Navigation("Classes");
                });

            modelBuilder.Entity("SignInSystem.Entity.Student", b =>
                {
                    b.Navigation("Scores");

                    b.Navigation("Tuitions");
                });

            modelBuilder.Entity("SignInSystem.Entity.Subject", b =>
                {
                    b.Navigation("Classes");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("SignInSystem.Entity.Teacher", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("SignInSystem.Entity.TuitionType", b =>
                {
                    b.Navigation("Tuitions");
                });

            modelBuilder.Entity("SignInSystem.Entity.Voucher", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
