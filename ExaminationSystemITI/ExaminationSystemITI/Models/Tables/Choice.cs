using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystemITI.Models.Tables
{
    public class Choice
    {
        public string Text { get; set; }
        public int Id { get; set; }

        [ForeignKey("Id")]
        public Question Question { get; set; }
    }
}
