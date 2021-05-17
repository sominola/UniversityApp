using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityApp.Models.StudentExam
{
    public class AnswerStudent
    {
        public int AnswerStudentId { get; set; }
        public int QuestionStudentId { get; set; }
        [NotMapped] public string Answer { get; set; }
        public bool IsSelected { get; set; }
    }
}