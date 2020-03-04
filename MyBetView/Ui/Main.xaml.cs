using MyBetModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        }

        private void btnEvent_Click(object sender, RoutedEventArgs e)
        {
            var events = new EventsUi(check);
            events.Owner = this;
            events.ShowDialog();
        }

        private void btnAccount_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
