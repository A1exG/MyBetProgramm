using MyBetModel.Model;
using MyBetService;
using Ninject;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;

namespace MyBetView.Ui
{
    public partial class AddResultUi : Window
    {
        public AddResultUi()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();

            IKernel kernel = new StandardKernel();
            GetDataService getDataService = kernel.Get<GetDataService>();
            BetService betService = kernel.Get<BetService>();
            PayService payService = kernel.Get<PayService>();


            dgvResult.Loaded += (s, e) =>
            {
                var ItemsSource = getDataService.GetEvent();
                dgvResult.ItemsSource = ItemsSource;
                HeadTable();
            };

            btnOk.Click += (s, e) =>
            {
                if (txtEventId.Text != "")
                {
                    var ItemsSource = getDataService.GetEventData(Convert.ToInt32(txtEventId.Text));
                    dgvResult.ItemsSource = ItemsSource;
                    HeadTable();
                }
                else
                {
                    var ItemsSource = getDataService.GetEvent();
                    dgvResult.ItemsSource = ItemsSource;
                    HeadTable();
                }
            };

            EventBet evB = new EventBet();

            dgvResult.SelectionChanged += (s, e) =>
            {
                if (dgvResult.SelectedItem != null)
                {
                    if (dgvResult.SelectedItem is EventBet)
                    {
                        cBox.Items.Clear();
                        evB = (EventBet)dgvResult.SelectedItem;
                        cBox.Items.Add(evB.Team1);
                        cBox.Items.Add(evB.Team2);
                        cBox.Visibility = Visibility.Visible;
                        txtEventId.Text = evB.EventId.ToString();
                    }
                }
            };

            btnAddResult.Click += (s, e) =>
            {
                if (cBox.Text == "") { }
                else
                {
                    if (evB != null)
                    {
                        var res = betService.AddEventInHistory(evB, cBox.Text);
                        if (res)
                        {
                            var result = betService.AddResultEvent(evB, cBox.Text);
                            if (result)
                            {
                                MessageBox.Show("Событие перенесено в историю. Создана запись в таблице результатов");
                            }
                        }
                    }
                }
                payService.GetBetPayment(evB);
                var del = betService.DeleteEvent(evB);
                if (del)
                {
                    var ItemsSource = getDataService.GetEvent();
                    dgvResult.ItemsSource = ItemsSource;
                    HeadTable();
                    cBox.Items.Clear();
                }
            };

            btnExit.Click += (s, e) => { Close(); };
        }
        public void HeadTable()
        {
            dgvResult.Columns[0].Header = "Id События";
            dgvResult.Columns[1].Header = "Дата События";
            dgvResult.Columns[2].Header = "Команда 1";
            dgvResult.Columns[3].Header = "Коэф Команда 1";
            dgvResult.Columns[4].Header = "Команда 2";
            dgvResult.Columns[5].Header = "Коэф Команда 2";
        }


    }
}
