using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExaminationSystemITI.Models.Tables
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Branch { get; set; }
        public ICollection<Course> Courses { get; set; } = new HashSet<Course>();
        public ICollection<Student> Students { get; set; } = new HashSet<Student>();

        //Supervisor
        public int SP { get; set; }
        [ForeignKey("SP")]
        public Instructor Instructor { get; set; }
    }
}
