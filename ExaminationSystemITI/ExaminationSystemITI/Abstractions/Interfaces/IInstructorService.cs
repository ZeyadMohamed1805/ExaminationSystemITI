using ExaminationSystemITI.Models.Tables;
using ExaminationSystemITI.Models.ViewModels;

namespace ExaminationSystemITI.Abstractions.Interfaces
{
    public interface IInstructorService
    {
        public List<Instructor> GetInstructors();
        public void InsertInstructor(Instructor ins);
        public void InsertInstructorCourses(InstructorCoursesViewModel viewModel);
        public void EditInstructor(Instructor ins);
        public void DeleteInstructor(int insID);
        public Instructor FindInstructor(int id);
        public List<Course> GetInstructorCourses(int Id);
        public List<Instructor> GetActiveSupervisors();
    }
}
