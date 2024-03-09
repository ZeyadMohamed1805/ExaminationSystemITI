using System.ComponentModel.DataAnnotations;

namespace ExaminationSystemITI.Models.Tables
{
    public class User
    {
        [Key]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public Student Student { get; set; }
        public Instructor Instructor { get; set; }
        public Admin Admin { get; set; }
        public ICollection<Role> Roles { get; set; } = new HashSet<Role>();
    }
}
