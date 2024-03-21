using ExaminationSystemITI.Models.Tables;
using ExaminationSystemITI.Models.ViewModels;
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
        public ICollection<StudentExamCardViewModel> FindStudentExams(int Id);
        public void InsertCourseDepartments(CourseDepartmentsViewModel viewModel);
        public ICollection<StudentExamCardViewModel> FindStudentDoneExams(int Id);
        public ICollection<StudentExamCardViewModel> FindStudentActiveExams(int Id);
    }
}
