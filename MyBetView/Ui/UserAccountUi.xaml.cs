using MyBetModel.Model;
using MyBetService;
using Ninject;
using System.Collections.Generic;
using System.Windows;

namespace MyBetView.Ui
{
    public partial class UserAccountUi : Window
    {
        private readonly IList<User> check;
        public UserAccountUi(IList<User> check)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            this.check = check;
            LoadData(check[0]);

            this.Activated += (s, e) =>
            {
                IKernel kernel = new StandardKernel();
                MyUserValidator validator = kernel.Get<MyUserValidator>();
                var data = validator.GetUserData(check[0]);
                check = data;
                LoadData(check[0]);
            };

            btnBalance.Click += (s, e) =>
            {
                var balance = new AccountBalanceUi(check);
                balance.Owner = this;
                balance.ShowDialog();
            };
            btnChange.Click += (s, e) =>
            {
                var chengeAccount = new ChangeAccount(check);
                chengeAccount.Owner = this;
                chengeAccount.ShowDialog();
            };
            btnExit.Click += (s, e) => {Close();};
        }


        void LoadData(User check)
        {
            txtSurName.Text = check.SurName;
            txtName.Text = check.Name;
            txtSecondName.Text = check.SecondName;
            txtBirthday.Text = check.Birthday.ToShortDateString();
            txtLogin.Text = check.UserLogin;
            pswdUser.Password = check.UserPass;
            txtUserIdAccount.Text = check.UserId.ToString();
        }
    }
}
