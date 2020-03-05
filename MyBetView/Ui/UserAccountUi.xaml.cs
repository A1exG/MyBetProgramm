using MyBetModel.Model;
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

        private void btnBalance_Click(object sender, RoutedEventArgs e)
        {
            var balance = new AccountBalanceUi(check[0].UserId, check[0].Balance);
            balance.Owner = this;
            balance.ShowDialog();
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            //var chengeAccount = new ChangeAccount(userIdAccount);
            //chengeAccount.Owner = this;
            //chengeAccount.ShowDialog();
            //this.UpdateLayout();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
