using ExaminationSystemITI.Abstractions.Interfaces;
using ExaminationSystemITI.Database;
using ExaminationSystemITI.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System;

namespace ExaminationSystemITI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services
               .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Data Source=.;Initial Catalog=ExaminationDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True")));
                builder.Services.AddScoped<IInstructorService, InstructorService>();
                builder.Services.AddScoped<ICourseService, CourseService>();
                builder.Services.AddScoped<ITopicService, TopicService>();
                builder.Services.AddScoped<IDepartmentService, DepartmentService>();
                builder.Services.AddScoped<IStudentService, StudentService>();
                builder.Services.AddScoped<IChoiceService, ChoiceService>();
                builder.Services.AddScoped<IExamService, ExamService>();
                builder.Services.AddScoped<IQuestionInterface, QuestionService>();
                builder.Services.AddScoped<IAdminService, AdminService>();
                builder.Services.AddScoped<IUserService, UserService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Login/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
