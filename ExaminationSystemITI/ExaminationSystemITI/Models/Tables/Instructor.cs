using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExaminationSystemITI.Models.Tables
{
    public class Instructor
    {
        [Key]
        public int InstructorID { get; set; }
        [Required]
        public string InstructorFirstName { get; set; }
        public string InstructorLastName { get; set; }
        public int InstructorAge { get; set; }
        public int InstructorSalary { get; set; }
        public string InstructorAddress { get; set; }
        public ICollection<Course> Courses { get; set; }

        public ICollection<Department> Departments { get; set; } = new HashSet<Department>();

        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "The Email field is not a valid e-mail address.")]
        public string InstructorEmail { get; set; }
        [ForeignKey("InstructorEmail")]
        public User User { get; set; }
    }
}
