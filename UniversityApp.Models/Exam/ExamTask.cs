using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityApp.Models.Exam
{
    public class ExamTask
    {
        [Key] public string Question { get; set; }

        public List<Answer> Answers { get; set; } = new();
    }
}