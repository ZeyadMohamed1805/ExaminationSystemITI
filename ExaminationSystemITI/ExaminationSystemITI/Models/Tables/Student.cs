namespace ExaminationSystemITI.Models.Tables
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int StudentAge { get; set; }
        public string StudentGender { get; set; }
        public string StudentAddress { get; set; }
        public string StudentFaculty { get; set; }
        public int StudentGraduationYear { get; set; }
        public ICollection<Department> Departments { get; set; } = new HashSet<Department>();
        public ICollection<Student> Students { get; set; } = new HashSet<Student>();
    }
}
