using System.Windows.Input;
using UniversityApp.Models;
using UniversityApp.Services;

namespace UniversityApp.ViewModels.MainPage
{
    public class SignUpViewModel
    {
        public Account Account { get; }

        private ICommand _signUp;
        public ICommand SignUp => _signUp ??= new RelayCommand(Action, CanExecute);

        public SignUpViewModel()
        {
            Account = new Account();
            Account.Human = new Student();
            AccountService.AccountExistsEvent += () => Account.Login = string.Empty;
        }

        private void Action()
        {
            AccountService.SignUpAccount(Account);
        }

        private bool CanExecute()
        {
            if (string.IsNullOrEmpty(Account.Login) || string.IsNullOrEmpty(Account.Password))
                return false;
            if (Account.Human.Age is null or <= 16 || string.IsNullOrEmpty(Account.Human.Name) ||
                string.IsNullOrEmpty(Account.Human.LastName))
                return false;
            // foreach (var property in Account.Human.GetType().GetProperties())
            // {
            //     var value = property.GetValue(Account.Human, null);
            //     if (value is not string str) continue;
            //     if(string.IsNullOrEmpty(str))
            //         return false;
            // }

            return true;
        }
    }
}