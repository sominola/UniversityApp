using System.Windows.Controls;
using UniversityApp.Models;
using UniversityApp.ViewModels.StudentPage;

namespace UniversityApp.Views.StudentPage
{
    public partial class ExamFacultyView : UserControl
    {
        public ExamFacultyView(Student student, Faculty faculty)
        {
            InitializeComponent();
            DataContext = new ExamFacultyViewModel(student, faculty);
        }
    }
}