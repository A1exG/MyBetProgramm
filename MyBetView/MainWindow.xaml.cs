using MyBetModel.Model;
using MyBetService;
using MyBetView.Ui;
using Ninject;
using System.Windows;


namespace MyBetView
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var userLogin = txtLogin.Text.ToString();
            var userPass = txtPass.Text.ToString();
            User u = new User(userLogin, userPass);

            IKernel kernel = new StandardKernel();
            MyUserValidator validator = kernel.Get<MyUserValidator>();

            var check = validator.CheckRegUser(u);
            if(check.Count > 0)
            {
                var main = new Main(check);
                main.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Что то пошло не так");
            } 
        }
    }
}
