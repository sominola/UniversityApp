using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityApp.Models
{
    public class Faculty
    {
        [Key] public int FacultyId { get; set; }
        public string NameFaculty { get; set; }
        public List<Student> Students { get; set; } = new();
        public List<Teacher> Teachers { get; set; } = new();
        public List<Exam.Exam> Exams { get; set; } = new();
    }
}