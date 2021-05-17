using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using UniversityApp.Models;
using UniversityApp.Models.Exam;


namespace UniversityApp.Services
{
    public static class AccountService
    {
        private static readonly Dictionary<string, Account> RegisteredAccounts;

        public static event Action<Account> SignUpEvent;

        public static event Action<Account> LogInEvent;

        public static event Action SignInInWrongPasswordEvent;

        public static event Action SignInAccountNotFoundEvent;

        public static event Action AccountExistsEvent;

        static AccountService()
        {
            RegisteredAccounts = GetRegisteredAccounts();
            LoadData();
        }

        private static Dictionary<string, Account> GetRegisteredAccounts()
        {
            using var db = new ApplicationContext();
            return db.Accounts.
                Include("Human.Faculty").
                ToDictionary(account => account.Login);
        }

        public static void SignUpAccount(Account account)
        {
            if (RegisteredAccounts.ContainsKey(account.Login))
            {
                AccountExistsEvent?.Invoke();
                return;
            }

            RegisteredAccounts.Add(account.Login, account);

            using var db = new ApplicationContext();
            db.Accounts.Add(account);
            db.SaveChanges();

            SignUpEvent?.Invoke(account);
        }

        public static void SignInAccount(string login, string password)
        {
            if (AccountExists(login))
            {
                if (CheckAccountPassword(login, password))
                {
                    LogInEvent?.Invoke(RegisteredAccounts[login]);
                }
                else
                {
                    SignInInWrongPasswordEvent?.Invoke();
                }
            }
            else
            {
                SignInAccountNotFoundEvent?.Invoke();
            }
        }

        private static bool AccountExists(string login)
        {
            return RegisteredAccounts.ContainsKey(login);
        }

        private static bool CheckAccountPassword(string login, string password)
        {
            return RegisteredAccounts[login].Password == password;
        }

        private static void LoadData()
        {
            using var db = new ApplicationContext();
            var json = File.ReadAllText("1.json");
            var data = JsonSerializer.Deserialize<Exam>(json);
            var exam = new Exam() {ExamName = "Math", Questions = data.Questions};

            var faculty = new Faculty {NameFaculty = "MathFaculty", Exams = new List<Exam>() {exam}};
            db.Faculties.Add(faculty);
            db.SaveChanges();
        }
    }
}