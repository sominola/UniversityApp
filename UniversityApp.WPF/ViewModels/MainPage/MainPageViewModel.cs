using System.Windows.Controls;
using System.Windows.Input;
using UniversityApp.Services;
using UniversityApp.Views.MainPage;

namespace UniversityApp.ViewModels.MainPage
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly UserControl _signUpControl = new SignUpView();
        private readonly UserControl _signInControl = new SignInView();

        private ICommand _signIn;
        private ICommand _signUp;
        public ICommand SignIn => _signIn ??= new RelayCommand(ActionSignIn, CanExecuteSignIn);
        public ICommand SignUp => _signUp ??= new RelayCommand(ActionSignUp, CanExecuteSignUp);

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

        public MainPageViewModel()
        {
            CurrentControl = _signInControl;
            AccountService.SignUpEvent += _ => CurrentControl = _signInControl;
            AccountService.SignInAccountNotFoundEvent += () => CurrentControl = _signUpControl;
        }

        private void ActionSignIn()
        {
            CurrentControl = _signInControl;
        }

        private bool CanExecuteSignIn()
        {
            return CurrentControl != _signInControl;
        }

        private void ActionSignUp()
        {
            CurrentControl = _signUpControl;
        }

        private bool CanExecuteSignUp()
        {
            return CurrentControl != _signUpControl;
        }
    }
}