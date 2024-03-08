using ExaminationSystemITI.Abstractions.Enums;
using System.ComponentModel.DataAnnotations;

namespace ExaminationSystemITI.Models.Tables
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [Required]
        public ERole RoleDescription { get; set; }
        public ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}
