using MyBetModel.Model;
using MyBetService;
using Ninject;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;


namespace MyBetView.Ui
{
    public partial class AccountBalanceUi : Window
    {
        private readonly IList<User> check;
        public AccountBalanceUi(IList<User> check)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();

            this.check = check;

            IKernel kernel = new StandardKernel();
            PayService payServece = kernel.Get<PayService>();
            MyUserValidator validator = kernel.Get<MyUserValidator>();

            txtBalance.Text = check[0].Balance.ToString();
            var userId = check[0].UserId;
            var balance = check[0].Balance;

            btnExit.Click += (s, e) => {Close();};

            this.Activated += (s, e) =>
            {
                var data = validator.GetUserData(check[0]);
                check = data;
                txtBalance.Text = check[0].Balance.ToString();
                txtSum.Text = "";
                balance = check[0].Balance;
                ReloadVisibleItem();
            };

            btnDeposit.Click += (s, e) =>
            {
                VisibleItem();
                btnOkDeposit.Visibility = Visibility.Visible;
                btnWithdraw.Visibility = Visibility.Hidden;
            };
            btnWithdraw.Click += (s, e) =>
            {
                VisibleItem();
                btnOkWithdraw.Visibility = Visibility.Visible;
                btnDeposit.Visibility = Visibility.Hidden;
            };

            btnOkDeposit.Click += (s, e) =>
            {
                var sum = ParceDecimal(txtSum.Text);
                decimal newBalance = (balance + sum);
                var depo = payServece.DepositBalance(userId, newBalance);
                if (depo == 1)
                {
                    MessageBox.Show($"Ваш баланс пополнен на сумму {txtSum.Text}. Баланс = {newBalance}");
                }
            };

            btnOkWithdraw.Click += (s, e) =>
            {
                var sum = ParceDecimal(txtSum.Text);
                if (balance > sum)
                {
                    decimal newBalance = (balance - sum);
                    var with = payServece.WithdrawBalance(userId, newBalance);
                    if (with == 1)
                    {
                        MessageBox.Show($"С вашего баланса снято - {txtSum.Text}. Баланс = {newBalance}");
                    }
                }
                else { MessageBox.Show("Недостаточно средств"); }
            };
        }
        public void VisibleItem()
        {
            lbl.Visibility = Visibility.Visible;
            txtSum.Visibility = Visibility.Visible;
        }
        public void ReloadVisibleItem()
        {
            btnWithdraw.Visibility = Visibility.Visible;
            btnDeposit.Visibility = Visibility.Visible;
            btnOkDeposit.Visibility = Visibility.Hidden;
            btnOkWithdraw.Visibility = Visibility.Hidden;
            lbl.Visibility = Visibility.Hidden;
            txtSum.Visibility = Visibility.Hidden;
        }
        private decimal ParceDecimal(string str)
        {
            NumberFormatInfo nfi = new NumberFormatInfo() { NumberDecimalSeparator = "." };

            if (decimal.TryParse(str, NumberStyles.Number, nfi, out decimal result)){ }return result;
        }
    }
}

