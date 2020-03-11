using MyBetModel.Model;
using MyBetService;
using Ninject;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MyBetView.Ui
{
    public partial class HistoryBetsUi : Window
    {
        private readonly IList<User> check;

        public HistoryBetsUi(IList<User> check)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            this.check = check;

            IKernel kernel = new StandardKernel();
            GetDataService getDataService = kernel.Get<GetDataService>();


            grvBet.Loaded += (s, e) =>
            {
                var itemsSource = getDataService.GetBets(check[0]);
                grvBet.ItemsSource = itemsSource;
                grvBet.ColumnWidth = DataGridLength.Auto;
                HeadTable();
            };

            txtIdBets.TextChanged += (s, e) =>
            {
                if (txtIdBets.Text != null)
                {
                    var betId = Int32.TryParse(txtIdBets.Text, out int result);
                    if (betId == true)
                    {
                        var itemSource = getDataService.GetBetId(result);
                        grvBet.ItemsSource = itemSource;
                        HeadTable();
                    }
                }else { MessageBox.Show("Введите ID"); }
            };

            btnRefresh.Click += (s, e) =>
            {
                var itemsSource = getDataService.GetBets(check[0]);
                grvBet.ItemsSource = itemsSource;
                txtIdBets.Clear();
                HeadTable();
            };
            btnExit.Click += (s, e) => {Close();};
        }

        public void HeadTable()
        {
            grvBet.Columns[0].Header = "Id Ставки";
            grvBet.Columns[1].Header = "Дата Ставки";
            grvBet.Columns[2].Header = "Сумма ставки";
            grvBet.Columns[3].Header = "Коэф ставки";
            grvBet.Columns[4].Header = "Возможный выйгрыш";
            grvBet.Columns[5].Header = "ID пользователя";
            grvBet.Columns[5].Visibility = Visibility.Hidden;
            grvBet.Columns[6].Header = "ID события";
            grvBet.Columns[7].Header = "Команда";
        }
    }
}

        

