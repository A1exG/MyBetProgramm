using MyBetModel.Model;
using System.Collections.Generic;
using System.Windows;


namespace MyBetView.Ui
{
    public partial class Main : Window
    {
        private readonly IList<User> check;
        public Main(IList<User> check)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            this.check = check;

            lblHellow.Content = string.Format("Добро пожаловать, {0} {1}!", check[0].SurName, check[0].Name);

            if (check[0].UserLogin == "admin")
            {
                btnAddResult.Visibility = Visibility.Visible;
            }
        }

        private void btnEvent_Click(object sender, RoutedEventArgs e)
        {
            var events = new EventsUi(check);
            events.Owner = this;
            events.ShowDialog();
        }

        private void btnAccount_Click(object sender, RoutedEventArgs e)
        {
            var userAccount = new UserAccountUi(check);
            userAccount.Owner = this;
            userAccount.ShowDialog();

        }

        private void btnHistoryBets_Click(object sender, RoutedEventArgs e)
        {
            var historyBets = new HistoryBetsUi(check);
            historyBets.Owner = this;
            historyBets.ShowDialog();
        }
    }
}
