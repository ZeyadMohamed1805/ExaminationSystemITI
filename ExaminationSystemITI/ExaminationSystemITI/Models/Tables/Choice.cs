using ExaminationSystemITI.Abstractions.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystemITI.Models.Tables
{
    public class Choice
    {
        public EChoice Text { get; set; }
        public int QuestionId { get; set; }

        [ForeignKey("Id")]
        public Question Question { get; set; }
    }
}
