﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystemITI.Models.Tables
{
    public class StudentCourse
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public int? Grade { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
