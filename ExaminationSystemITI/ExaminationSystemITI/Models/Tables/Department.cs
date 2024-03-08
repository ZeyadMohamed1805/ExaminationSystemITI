using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExaminationSystemITI.Models.Tables
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        public string DepartmentName { get; set; }
        public ICollection<Course> Courses { get; set; } = new HashSet<Course>();
        public ICollection<Student> Students { get; set; } = new HashSet<Student>();

        //Supervisor
        public int DepartmentSP { get; set; }
        [ForeignKey("DepartmentSP")]
        public Instructor Instructor { get; set; }
    }
}
