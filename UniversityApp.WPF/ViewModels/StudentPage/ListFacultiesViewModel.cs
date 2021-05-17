using System.Collections.Generic;
using System.Windows.Input;
using UniversityApp.Models;
using UniversityApp.Services;


namespace UniversityApp.ViewModels.StudentPage
{
    public class ListFacultiesViewModel : BaseViewModel
    {
        private Faculty _selectedFaculty;

        public ICommand RegisterForFaculty { get; set; }

        public IEnumerable<Faculty> ListFaculties { get; }

        public Faculty SelectedFaculty
        {
            get => _selectedFaculty;
            set
            {
                _selectedFaculty = value;
                OnPropertyChanged(nameof(SelectedFaculty));
            }
        }

        public ListFacultiesViewModel(Account account)
        {
            ListFaculties = FacultyService.Faculties;
            RegisterForFaculty ??= new RelayCommand
            (
                () => { FacultyService.RegisterStudentForFaculty(SelectedFaculty, (Student) account.Human); },
                () => SelectedFaculty != null
            );
        }
    }
}