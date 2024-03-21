using ExaminationSystemITI.Models.Tables;
using ExaminationSystemITI.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace ExaminationSystemITI.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ExaminationDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
               .Entity<Choice>()
               .HasKey(a => new { a.Text, a.Id });

            modelBuilder
                .Entity<StudentCourse>()
                .HasKey(b => new { b.CourseId, b.StudentId });

            modelBuilder
                .Entity<StudentExamQuestion>()
                .HasKey(c => new { c.StudentId, c.ExamId, c.QuestionId });

         



            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Iterate through all foreign keys for the current entity type
                foreach (var foreignKey in entityType.GetForeignKeys())
                {
                    // Set the onDelete behavior for each foreign key
                    foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
                }
            }

            //foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            //{
            //    // Iterate through all foreign keys for the current entity type
            //    foreach (var foreignKey in entityType.GetForeignKeys())
            //    {
            //        // Set the onDelete behavior for each foreign key to NoAction
            //        foreignKey.DeleteBehavior = DeleteBehavior.NoAction;
            //    }
            //}


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<StudentExamQuestion> StudentExamQuestions { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<User> Users { get; set; }

       
    }
    
    
}
