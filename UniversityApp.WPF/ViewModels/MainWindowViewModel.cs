using System.Windows.Controls;
using UniversityApp.Models;
using UniversityApp.Services;
using UniversityApp.Views.MainPage;
using UniversityApp.Views.StudentPage;


namespace UniversityApp.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private UserControl _currentControl;

        public UserControl CurrentControl
        {
            get => _currentControl;
            set
            {
                _currentControl = value;
                OnPropertyChanged(nameof(CurrentControl));
            }
        }

        public MainWindowViewModel()
        {
            CurrentControl = new MainPageView();
            AccountService.LogInEvent += AccountServiceOnLogInEvent;
        }

        private void AccountServiceOnLogInEvent(Account account)
        {
            var type = account.Human;
            switch (type)
            {
                case Student:
                    CurrentControl = new StudentView(account);
                    break;
                case Teacher:
                    break;
            }
        }
    }
}