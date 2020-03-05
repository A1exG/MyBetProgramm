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
        }

        private void grvBet_Loaded(object sender, RoutedEventArgs e)
        {
            IKernel kernel = new StandardKernel();
            GetDataService getDataService = kernel.Get<GetDataService>();

            var itemsSource = getDataService.GetBets(check[0]);
            grvBet.ItemsSource = itemsSource;
            grvBet.ColumnWidth = DataGridLength.Auto;
            HeadTable();
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

        private void txtIdBets_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(txtIdBets.Text != null)
            {
                var betId = Convert.ToInt32(txtIdBets.Text); //Если ввести другой ID?!

                IKernel kernel = new StandardKernel();
                GetDataService getDataService = kernel.Get<GetDataService>();
                var itemSource = getDataService.GetBetId(betId);
                grvBet.ItemsSource = itemSource;
            }
            
        }
    }
}

        

