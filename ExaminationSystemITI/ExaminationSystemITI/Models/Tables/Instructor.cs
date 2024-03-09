using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExaminationSystemITI.Models.Tables
{
    public class Instructor
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
        public int Salary { get; set; }
        public string? Address { get; set; }
        public ICollection<Course> Courses { get; set; }

        public Department Department { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "The Email field is not a valid e-mail address.")]
        public string Email { get; set; }
        [ForeignKey("Email")]
        public User User { get; set; }
    }
}
