using ExaminationSystemITI.Models.Tables;

namespace ExaminationSystemITI.Abstractions.Interfaces
{
    public interface IInstructorService
    {
        public List<Instructor> GetInstructors();
    }
}
