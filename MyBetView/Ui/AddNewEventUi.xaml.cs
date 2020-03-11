using MyBetModel.Model;
using MyBetService;
using Ninject;
using System;
using System.Globalization;
using System.Windows;

namespace MyBetView.Ui
{
    public partial class AddNewEventUi : Window
    {
        public AddNewEventUi()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();

            IKernel kernel = new StandardKernel();
            BetService betService = kernel.Get<BetService>();

            btnExit.Click += (s, e) => {Close();};

            btnAdd.Click += (s, e) =>
            {
                EventBet eventBet = new EventBet(
                    Convert.ToDateTime(dpTime.SelectedDate), 
                    txtTeam1.Text, ParceDecimal(txtTeam1Coef.Text), 
                    txtTeam2.Text, ParceDecimal(txtTeam2Coef.Text));
                var addNew = betService.AddNewEvent(eventBet);
                if(!addNew)
                {
                    MessageBox.Show("Что то пошло не так");
                }
                MessageBox.Show("Событие добавлено!");
                ClearData();
            };
        }
        private decimal ParceDecimal(string str)
        {
            NumberFormatInfo nfi = new NumberFormatInfo() { NumberDecimalSeparator = "." };

            if (decimal.TryParse(str, NumberStyles.Number, nfi, out decimal result))
            { }
            return result;
        }

        private void ClearData()
        {
            dpTime.Text = null;
            txtTeam1.Text = "";
            txtTeam1Coef.Text = "";
            txtTeam2.Text = "";
            txtTeam2Coef.Text = "";
        }
    }
}
