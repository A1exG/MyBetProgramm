using MyBetService;
using Ninject;
using System.Globalization;
using System.Windows;


namespace MyBetView.Ui
{
    public partial class AccountBalanceUi : Window
    {
        private readonly int userId;
        private readonly decimal balance;

        public AccountBalanceUi(int UserId, decimal Balance)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            txtBalance.Text = Balance.ToString();
            userId = UserId;
            balance = Balance;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnDeposit_Click(object sender, RoutedEventArgs e)
        {
            VisibleItem();
            btnOkDeposit.Visibility = Visibility.Visible;
            btnWithdraw.Visibility = Visibility.Hidden;


        }

        public void VisibleItem()
        {
            lbl.Visibility = Visibility.Visible;
            txtSum.Visibility = Visibility.Visible;
        }
        private void btnWithdraw_Click(object sender, RoutedEventArgs e)
        {
            VisibleItem();
            btnOkWithdraw.Visibility = Visibility.Visible;
            btnDeposit.Visibility = Visibility.Hidden;
        }

        private void btnOkDeposit_Click(object sender, RoutedEventArgs e)
        {
            IKernel kernel = new StandardKernel();
            PayService payServece = kernel.Get<PayService>();

            var sum = ParceDecimal(txtSum.Text);
            decimal newBalance = (balance + sum);
            var depo = payServece.DepositBalance(userId, newBalance);
            if(depo == 1)
            {
                MessageBox.Show($"Ваш баланс пополнен на сумму {txtSum.Text}. Баланс = {newBalance}");
                Close();
            }

        }
        private void btnOkWithdraw_Click(object sender, RoutedEventArgs e)
        {
            IKernel kernel = new StandardKernel();
            PayService payServece = kernel.Get<PayService>();
            
            var sum = ParceDecimal(txtSum.Text);
            if(balance > sum)
            {
                decimal newBalance = (balance - sum);
                var with = payServece.WithdrawBalance(userId, newBalance);
                if (with == 1)
                {
                    MessageBox.Show($"С вашего баланса снято - {txtSum.Text}. Баланс = {newBalance}");
                    Close();
                }
            }
            else { MessageBox.Show("Недостаточно средств"); } 
        }

        private decimal ParceDecimal(string str)
        {
            NumberFormatInfo nfi = new NumberFormatInfo() { NumberDecimalSeparator = "." };

            if (decimal.TryParse(str, NumberStyles.Number, nfi, out decimal result))
            { }
            return result;
        }
    }
}

