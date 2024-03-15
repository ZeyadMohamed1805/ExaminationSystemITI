using ExaminationSystemITI.Models.Tables;

namespace ExaminationSystemITI.Models.ViewModels
{
    public class ChoiceViewModel
    {
        public Choice Choice { get; set; } = new Choice();
        public string NewText { get; set; }
    }
}
