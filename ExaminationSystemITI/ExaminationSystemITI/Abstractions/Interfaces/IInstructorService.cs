using ExaminationSystemITI.Models.Tables;

namespace ExaminationSystemITI.Abstractions.Interfaces
{
    public interface IInstructorService
    {
        public List<Instructor> GetInstructors();
        public void InsertInstructor(Instructor ins);

        public void EditInstructor(Instructor ins);
        public void DeleteInstructor(int insID);

        public Instructor FindInstructor(int id);
    }
}
