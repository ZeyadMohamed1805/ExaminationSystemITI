using ExaminationSystemITI.Database;

namespace ExaminationSystemITI.Services
{
    public class ChoiceService
    {
        ApplicationDbContext _db;
        public ChoiceService(ApplicationDbContext db)
        {
            _db = db;
        }

       
    }
}
