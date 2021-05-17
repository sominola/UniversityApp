using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using UniversityApp.Models;
using UniversityApp.Models.StudentExam;
using UniversityApp.Services;
using UniversityApp.Views.StudentPage;


namespace UniversityApp.ViewModels.StudentPage
{
    public class ExamFacultyViewModel : BaseViewModel
    {
        private UserControl _currentQuestion;

        public UserControl CurrentQuestion
        {
            get => _currentQuestion;
            set
            {
                _currentQuestion = value;
                OnPropertyChanged();
            }
        }

        private INavigationView<ExamQuestionCard> Views { get; init; }
        public StudentExam StudentExam { get; set; }

        public ExamFacultyViewModel(Student student, Faculty faculty)
        {
            // using var db = new ApplicationContext();
            // var exam = db.Exams.Include("Questions.Answers").Include("Faculties").FirstOrDefault();
            // var faculty = db.Faculties.Include("Students").FirstOrDefault();
            // var student = faculty.Students.FirstOrDefault();
            // StudentExam = new StudentExam() {Exam = exam, StudentId = student.HumanId};
            // foreach (var e in exam.Questions)
            // {
            //     var question = new QuestionStudent() {Question = e.Question};
            //     foreach (var answer in e.Answers)
            //     {
            //         question.Answers.Add(new AnswerStudent() {Answer = answer.Answers});
            //     }
            //
            //     StudentExam.Questions.Add(question);
            // }

            // var listQuestions = new List<ExamQuestionCard>();
            // foreach (var question in StudentExam.Questions)
            // {
                // listQuestions.Add(new ExamQuestionCard(question));
            // }

            // foreach (var question in StudentExam.Questions)
            // {
            //     foreach (var answer in question.Answers)
            //     {
            //         answer.IsSelected = true;
            //         break;
            //     }
            // }

            // student.StudentExams = new List<StudentExam>() {StudentExam};
            // db.Faculties.Update(faculty);
            // db.SaveChanges();
            Views = new NavigationView<ExamQuestionCard>(new List<ExamQuestionCard>());
            // CurrentQuestion = Views.MoveNext();
        }

        private ICommand _nextCommand;

        public ICommand NextCommand => _nextCommand ??= new RelayCommand
        (() => { CurrentQuestion = Views.MoveNext(); },
            () => Views.CanMoveNext()
        );

        private ICommand _backCommand;

        public ICommand BackCommand => _backCommand ??= new RelayCommand
        (() => { CurrentQuestion = Views.MoveBack(); },
            () => Views.CanMoveBack()
        );
    }
}