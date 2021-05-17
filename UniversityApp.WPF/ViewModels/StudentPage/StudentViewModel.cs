using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UniversityApp.Models;
using UniversityApp.Services;
using UniversityApp.Views.StudentPage;


namespace UniversityApp.ViewModels.StudentPage
{
    public class StudentViewModel : BaseViewModel
    {
        private Visibility _visibilityExam = Visibility.Collapsed;

        public Visibility VisibilityExam
        {
            get => _visibilityExam;
            set
            {
                _visibilityExam = value;
                OnPropertyChanged(nameof(VisibilityExam));
            }
        }

        private Visibility _visibilityFacultyList = Visibility.Visible;

        public Visibility VisibilityFacultyList
        {
            get => _visibilityFacultyList;
            set
            {
                _visibilityFacultyList = value;
                OnPropertyChanged(nameof(VisibilityFacultyList));
            }
        }

        public Account Account { get; }
        private UserControl _currentControl;

        public StudentViewModel(Account account)
        {
            Account = account;
            var student = (Student) account.Human;
            if (student.Faculty == null)
                CurrentControl = new ListFacultiesView(account);
            else
            {
                throw new();
            }

            FacultyService.StudentRegisterForFaculty += (faculty, student) =>
            {
                VisibilityExam = Visibility.Visible;
                VisibilityFacultyList = Visibility.Collapsed;
                CurrentControl = new ExamFacultyView(student, faculty);
            };
            // else
        }

        private ICommand _listFaculties;

        public ICommand ListFaculties => _listFaculties ??= new RelayCommand(
            () => MessageBox.Show("Hello world!"),
            () => _currentControl.GetType() != typeof(ListFacultiesView));

        private ICommand _examFaculty;

        public UserControl CurrentControl
        {
            get => _currentControl;
            set
            {
                _currentControl = value;
                OnPropertyChanged(nameof(CurrentControl));
            }
        }
    }
}