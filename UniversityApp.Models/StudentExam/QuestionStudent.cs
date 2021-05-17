using System.Collections.Generic;

namespace UniversityApp.Models.StudentExam
{
    public class QuestionStudent
    {
        public int QuestionStudentId { get; set; }
        public int StudentExamId { get; set; }
        public string Question { get; set; }
        public List<AnswerStudent> Answers { get; set; } = new();
    }
}