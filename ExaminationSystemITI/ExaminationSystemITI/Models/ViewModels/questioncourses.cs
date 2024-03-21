using ExaminationSystemITI.Models.Tables;

namespace ExaminationSystemITI.Models.ViewModels
{
    public class questioncourses
    {
        //for instructor in question controller
        
            public List<Question> Questions { get; set; }
            public List<Course> Courses { get; set; }   
    }
}
