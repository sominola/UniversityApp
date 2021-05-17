using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityApp.Models.Exam
{
    public class Exam
    {
        public List<Faculty> Faculties { get; set; } = new();
        [Key] public int ExamId { get; set; }
        public string ExamName { get; set; }
        public List<ExamTask> Questions { get; set; } = new();
    }
}