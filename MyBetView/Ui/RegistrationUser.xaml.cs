using Ninject;
using System;
using System.Windows;
using System.Windows.Controls;
using MyBetService;
using System.Text.RegularExpressions;
using MyBetModel.Model;
using NLog;

namespace MyBetView.Ui
{
    public partial class RegistrationUser : Window
    {
        public RegistrationUser()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            CheckTextInput();

            IKernel kernel = new StandardKernel();
            MyUserValidator validator = kernel.Get<MyUserValidator>();

            Logger logger = LogManager.GetCurrentClassLogger();

            btnReg.Click += (s, e) =>
            {
                var check = CheckEmpty();
                if (check == 1 || txtUserPass.Text.Length > 5)
                {
                    User user = new User(txtSurName.Text, txtName.Text
                  , txtSecondName.Text, Convert.ToDateTime(Dp.SelectedDate)
                  , txtUserLogin.Text, txtUserPass.Text);

                    var checkUser = validator.CheckRegUser(user);
                    if (checkUser.Count > 0)
                    {
                        MessageBox.Show("Пользователь с таким логином и паролем уже существует");
                    }

                    var userOk = validator.RegistrationNewUser(user);
                    if (userOk == 1)
                    {
                        MessageBox.Show("Вы зарегистрированны!");
                        logger.Info($"Пользователь {user.UserId} {user.UserLogin} зарегистрировался");
                        Close();
                    }
                    else { MessageBox.Show("Что то пошло не так"); }
                }
                else{MessageBox.Show("Поля не заполнены или короткий пароль");}
            };

            btnExit.Click += (s, e) => {Close();};
        }
        private void Dp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var ageInYears = GetDifferenceInYears(Dp.SelectedDate.Value, DateTime.Today);
            if (ageInYears < 18)
            {
                MessageBox.Show("Вам еще нет 18 лет!");
                Close();
            }
        }
        int GetDifferenceInYears(DateTime startDate, DateTime endDate)
        {
            return (endDate.Year - startDate.Year - 1) +
                (((endDate.Month > startDate.Month) ||
                ((endDate.Month == startDate.Month) && 
                (endDate.Day >= startDate.Day))) ? 1 : 0);
        }
        private int CheckEmpty()
        {
            if (txtSurName.Text == String.Empty
                ^ txtName.Text == String.Empty
                ^ txtSecondName.Text == String.Empty
                ^ txtUserLogin.Text == String.Empty
                ^ txtUserPass.Text == String.Empty)
            {
                MessageBox.Show("Заполните все поля");
                return 0;
            }
            else
            {
                return 1;
            }
        }

        private void CheckTextInput()
        {
            txtUserLogin.PreviewTextInput += (s, e) =>
            {
                string inputSymbol = e.Text.ToString();

                if (!Regex.Match(inputSymbol, @"[a-zA-Z]").Success)
                {
                    e.Handled = true;
                }
            };
            txtSurName.PreviewTextInput += (s, e) =>
            {
                string inputSymbol = e.Text.ToString();

                if (!Regex.Match(inputSymbol, @"[а-яА-Я]").Success)
                {
                    e.Handled = true;
                }
            };
            txtName.PreviewTextInput += (s, e) =>
            {
                string inputSymbol = e.Text.ToString();

                if (!Regex.Match(inputSymbol, @"[а-яА-Я]").Success)
                {
                    e.Handled = true;
                }
            };
            txtSecondName.PreviewTextInput += (s, e) =>
            {
                string inputSymbol = e.Text.ToString();

                if (!Regex.Match(inputSymbol, @"[а-яА-Я]").Success)
                {
                    e.Handled = true;
                }
            };
        }
    }
}
