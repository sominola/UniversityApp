namespace UniversityApp.Models.Exam
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string ExamTaskQuestion { get; set; }
        public string Answers { get; set; }
        public bool IsCorrect { get; set; }
    }
}