﻿// <auto-generated />
using System;
using ExaminationSystemITI.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExaminationSystemITI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CourseDepartment", b =>
                {
                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentsId")
                        .HasColumnType("int");

                    b.HasKey("CoursesId", "DepartmentsId");

                    b.HasIndex("DepartmentsId");

                    b.ToTable("CourseDepartment", (string)null);
                });

            modelBuilder.Entity("CourseInstructor", b =>
                {
                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.Property<int>("InstructorsID")
                        .HasColumnType("int");

                    b.HasKey("CoursesId", "InstructorsID");

                    b.HasIndex("InstructorsID");

                    b.ToTable("CourseInstructor", (string)null);
                });

            modelBuilder.Entity("ExamQuestion", b =>
                {
                    b.Property<int>("ExamsID")
                        .HasColumnType("int");

                    b.Property<int>("QuestionsId")
                        .HasColumnType("int");

                    b.HasKey("ExamsID", "QuestionsId");

                    b.HasIndex("QuestionsId");

                    b.ToTable("ExamQuestion", (string)null);
                });

            modelBuilder.Entity("ExaminationSystemITI.Models.Tables.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Admins", (string)null);
                });

            modelBuilder.Entity("ExaminationSystemITI.Models.Tables.Choice", b =>
                {
                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Text", "QuestionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Choices", (string)null);
                });

            modelBuilder.Entity("ExaminationSystemITI.Models.Tables.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Courses", (string)null);
                });

            modelBuilder.Entity("ExaminationSystemITI.Models.Tables.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Branch")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SP")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SP")
                        .IsUnique();

                    b.ToTable("Departments", (string)null);
                });

            modelBuilder.Entity("ExaminationSystemITI.Models.Tables.Exam", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("QCount")
                        .HasColumnType("int");

                    b.Property<int>("TotalMarks")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.ToTable("Exams", (string)null);
                });

            modelBuilder.Entity("ExaminationSystemITI.Models.Tables.Instructor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Instructors", (string)null);
                });

            modelBuilder.Entity("ExaminationSystemITI.Models.Tables.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CorrectAnswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Questions", (string)null);
                });

            modelBuilder.Entity("ExaminationSystemITI.Models.Tables.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Description")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("ExaminationSystemITI.Models.Tables.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Faculty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<int>("GraduationYear")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("ExaminationSystemITI.Models.Tables.StudentCourse", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int?>("Grade")
                        .HasColumnType("int");

                    b.HasKey("CourseId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentCourses", (string)null);
                });

            modelBuilder.Entity("ExaminationSystemITI.Models.Tables.StudentExamQuestion", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("ExamId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId", "ExamId", "QuestionId");

                    b.HasIndex("ExamId");

                    b.HasIndex("QuestionId");

                    b.ToTable("StudentExamQuestions", (string)null);
                });

            modelBuilder.Entity("ExaminationSystemITI.Models.Tables.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Topics", (string)null);
                });

            modelBuilder.Entity("ExaminationSystemITI.Models.Tables.User", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<int>("RolesId")
                        .HasColumnType("int");

                    b.Property<string>("UsersEmail")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RolesId", "UsersEmail");

                    b.HasIndex("UsersEmail");

                    b.ToTable("RoleUser", (string)null);
                });

            modelBuilder.Entity("CourseDepartment", b =>
                {
                    b.HasOne("ExaminationSystemITI.Models.Tables.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ExaminationSystemITI.Models.Tables.Department", null)
                        .WithMany()
                        .HasForeignKey("DepartmentsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("CourseInstructor", b =>
                {
                    b.HasOne("ExaminationSystemITI.Models.Tables.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ExaminationSystemITI.Models.Tables.Instructor", null)
                        .WithMany()
                        .HasForeignKey("InstructorsID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ExamQuestion", b =>
                {
                    b.HasOne("ExaminationSystemITI.Models.Tables.Exam", null)
                        .WithMany()
                        .HasForeignKey("ExamsID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ExaminationSystemITI.Models.Tables.Question", null)
                        .WithMany()
                        .HasForeignKey("QuestionsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ExaminationSystemITI.Models.Tables.Admin", b =>
                {
                    b.HasOne("ExaminationSystemITI.Models.Tables.User", "User")
                        .WithOne("Admin")
                        .HasForeignKey("ExaminationSystemITI.Models.Tables.Admin", "Email")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ExaminationSystemITI.Models.Tables.Choice", b =>
                {
                    b.HasOne("ExaminationSystemITI.Models.Tables.Question", "Question")
                        .WithMany("Choices")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("ExaminationSystemITI.Models.Tables.Department", b =>
                {
                    b.HasOne("ExaminationSystemITI.Models.Tables.Instructor", "Instructor")
                        .WithOne("Department")
                        .HasForeignKey("ExaminationSystemITI.Models.Tables.Department", "SP")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("ExaminationSystemITI.Models.Tables.Exam", b =>
                {
                    b.HasOne("ExaminationSystemITI.Models.Tables.Course", "Course")
                        .WithMany("Exams")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("ExaminationSystemITI.Models.Tables.Instructor", b =>
                {
                    b.HasOne("ExaminationSystemITI.Models.Tables.User", "User")
                        .WithOne("Instructor")
                        .HasForeignKey("ExaminationSystemITI.Models.Tables.Instructor", "Email")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ExaminationSystemITI.Models.Tables.Question", b =>
                {
                    b.HasOne("ExaminationSystemITI.Models.Tables.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("ExaminationSystemITI.Models.Tables.Student", b =>
                {
                    b.HasOne("ExaminationSystemITI.Models.Tables.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ExaminationSystemITI.Models.Tables.User", "User")
                        .WithOne("Student")
                        .HasForeignKey("ExaminationSystemITI.Models.Tables.Student", "Email")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ExaminationSystemITI.Models.Tables.StudentCourse", b =>
                {
                    b.HasOne("ExaminationSystemITI.Models.Tables.Course", "Course")
                        .WithMany("CourseStudents")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ExaminationSystemITI.Models.Tables.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ExaminationSystemITI.Models.Tables.StudentExamQuestion", b =>
                {
                    b.HasOne("ExaminationSystemITI.Models.Tables.Exam", "Exam")
                        .WithMany("StudentExamQuestions")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ExaminationSystemITI.Models.Tables.Question", "Question")
                        .WithMany("StudentExamQuestions")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ExaminationSystemITI.Models.Tables.Student", "Student")
                        .WithMany("StudentExamQuestions")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Exam");

                    b.Navigation("Question");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ExaminationSystemITI.Models.Tables.Topic", b =>
                {
                    b.HasOne("ExaminationSystemITI.Models.Tables.Course", "Course")
                        .WithMany("Topics")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("ExaminationSystemITI.Models.Tables.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ExaminationSystemITI.Models.Tables.User", null)
                        .WithMany()
                        .HasForeignKey("UsersEmail")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ExaminationSystemITI.Models.Tables.Course", b =>
                {
                    b.Navigation("CourseStudents");

                    b.Navigation("Exams");

                    b.Navigation("Topics");
                });

            modelBuilder.Entity("ExaminationSystemITI.Models.Tables.Department", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("ExaminationSystemITI.Models.Tables.Exam", b =>
                {
                    b.Navigation("StudentExamQuestions");
                });

            modelBuilder.Entity("ExaminationSystemITI.Models.Tables.Instructor", b =>
                {
                    b.Navigation("Department")
                        .IsRequired();
                });

            modelBuilder.Entity("ExaminationSystemITI.Models.Tables.Question", b =>
                {
                    b.Navigation("Choices");

                    b.Navigation("StudentExamQuestions");
                });

            modelBuilder.Entity("ExaminationSystemITI.Models.Tables.Student", b =>
                {
                    b.Navigation("StudentCourses");

                    b.Navigation("StudentExamQuestions");
                });

            modelBuilder.Entity("ExaminationSystemITI.Models.Tables.User", b =>
                {
                    b.Navigation("Admin")
                        .IsRequired();

                    b.Navigation("Instructor")
                        .IsRequired();

                    b.Navigation("Student")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
