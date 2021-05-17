using System.Windows.Controls;
using UniversityApp.Models;
using UniversityApp.ViewModels.StudentPage;

namespace UniversityApp.Views.StudentPage
{
    public partial class ListFacultiesView : UserControl
    {
        public ListFacultiesView(Account account)
        {
            DataContext = new ListFacultiesViewModel(account);
            InitializeComponent();
        }
    }
}