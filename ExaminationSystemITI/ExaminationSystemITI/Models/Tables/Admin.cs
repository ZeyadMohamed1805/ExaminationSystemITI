using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ExaminationSystemITI.Abstractions.Enums;

namespace ExaminationSystemITI.Models.Tables
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [Required]
        public string AdminFirstName { get; set; }
        public string AdminLastName { get; set; }
        public int AdminAge { get; set; }
        public string AdminAddress { get; set; }
        public EGender AdminGender { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "The Email field is not a valid e-mail address.")]
        public string AdminEmail { get; set; }
        [ForeignKey("AdminEmail")]
        public User User { get; set; }
    }
}
