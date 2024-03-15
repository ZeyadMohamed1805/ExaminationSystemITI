using ExaminationSystemITI.Abstractions.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystemITI.Models.Tables
{
    public class Choice
    {
        [StringLength(450,ErrorMessage ="Invalid Text Length",MinimumLength =2)]
        [Required]
        public string Text { get; set; }
        [Range(1,50,ErrorMessage ="Invalid Question ID!")]
        [Required]
        public int Id { get; set; }

        [ForeignKey("Id")]
        public Question Question { get; set; }
    }
}
