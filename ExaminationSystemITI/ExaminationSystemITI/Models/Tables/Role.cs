using ExaminationSystemITI.Abstractions.Enums;
using System.ComponentModel.DataAnnotations;

namespace ExaminationSystemITI.Models.Tables
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public ERole Description { get; set; }
        public ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}
