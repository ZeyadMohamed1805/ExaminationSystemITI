using System.ComponentModel.DataAnnotations;

namespace ExaminationSystemITI.Models.Tables
{
    public class User
    {
        [Key]
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}
