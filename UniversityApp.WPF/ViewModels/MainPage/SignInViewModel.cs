using System.Windows;
using System.Windows.Input;
using UniversityApp.Services;

namespace UniversityApp.ViewModels.MainPage
{
    public class SignInViewModel : BaseViewModel
    {
        private string _login;
        private string _password;

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public SignInViewModel()
        {
            AccountService.SignInAccountNotFoundEvent += () =>
            {
                MessageBox.Show("Account not found!");
                Login = string.Empty;
                Password = string.Empty;
            };
            AccountService.SignInInWrongPasswordEvent += () =>
            {
                MessageBox.Show("You entered the wrong password");
                Password = string.Empty;
            };
        }

        private ICommand _signIn;
        public ICommand SignIn => _signIn ??= new RelayCommand(Action, CanExecute);

        private void Action()
        {
            AccountService.SignInAccount(Login, Password);
        }

        private bool CanExecute()
        {
            return !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password);
        }
    }
}