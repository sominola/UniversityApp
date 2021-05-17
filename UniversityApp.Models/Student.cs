using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace UniversityApp.Models
{
    [Table("Students")]
    public class Student : Human
    {
        public int ExamMark { get; set; }
        public int? FacultyId { get; set; }
        public Faculty Faculty { get; set; }
        public List<StudentExam.StudentExam> StudentExams { get; set; }
    }
}