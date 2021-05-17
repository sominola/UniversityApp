using System.Windows.Controls;
using UniversityApp.Models;
using UniversityApp.ViewModels.StudentPage;

namespace UniversityApp.Views.StudentPage
{
    public partial class StudentView : UserControl
    {
        public StudentView(Account account)
        {
            InitializeComponent();
            DataContext = new StudentViewModel(account);
        }
    }
}