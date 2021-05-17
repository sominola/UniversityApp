using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityApp.Models.StudentExam
{
    public class StudentExam
    {
        [Key] public int StudentExamId { get; set; }

        public int StudentId { get; set; }

        public string NameExam { get; set; }
        public int ExamId { get; set; }
        public Exam.Exam Exam { get; set; }
        public List<QuestionStudent> Questions { get; set; } = new();
    }
}