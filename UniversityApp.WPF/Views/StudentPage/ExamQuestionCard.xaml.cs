using System.Windows.Controls;
using UniversityApp.Models.StudentExam;
using UniversityApp.ViewModels.StudentPage;


namespace UniversityApp.Views.StudentPage
{
    public partial class ExamQuestionCard : UserControl
    {
        public ExamQuestionCard(QuestionStudent questionStudent)
        {
            InitializeComponent();
            DataContext = new ExamQuestionCardViewModel(questionStudent);
        }
    }
}