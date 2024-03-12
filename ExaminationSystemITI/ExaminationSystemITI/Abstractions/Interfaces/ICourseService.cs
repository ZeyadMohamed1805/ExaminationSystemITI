using ExaminationSystemITI.Models.Tables;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystemITI.Abstractions.Interfaces
{
    public interface ICourseService
    {
        public ICollection<Course> GetCourses();
        public void DeleteCourse(int Id);
        public void EditCourse(Course course);
        public void InsertCourse(Course course);
        public Course? FindCourse(int Id);
    }
}
