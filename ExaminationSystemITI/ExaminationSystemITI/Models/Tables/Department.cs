using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExaminationSystemITI.Models.Tables
{
    public class Department
    {
        public int DepartmentID { get; set; }
        [Required]
        public string DepartmentName { get; set; }


        //Supervisor?
        public int DepartmentSP { get; set; }
        [ForeignKey("DepartmentSP")]
        public Instructor Instructor { get; set; }
    }
}
