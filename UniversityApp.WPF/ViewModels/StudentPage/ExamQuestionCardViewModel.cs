using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityApp.Models.StudentExam;
using UniversityApp.Services;
using UniversityApp.Views.StudentPage;


namespace UniversityApp.ViewModels.StudentPage
{
    public class ExamQuestionCardViewModel : BaseViewModel
    {
        public string Question { get; set; }
        public List<AnswerStudent> Answers { get; set; }

        public ExamQuestionCardViewModel(QuestionStudent questionStudent)
        {
            Question = questionStudent.Question;
            Answers = questionStudent.Answers;
        }
    }
}