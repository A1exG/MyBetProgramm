using MyBetModel.Model;
using MyBetService;
using Ninject;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyBetView.Ui
{
    public partial class EventsUi : Window
    {
        private readonly IList<User> check;
        public EventsUi(IList<User> check)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            this.check = check;

            IKernel kernel = new StandardKernel();
            GetDataService getDataService = kernel.Get<GetDataService>();
            BetService betService = kernel.Get<BetService>();
            PayService payService = kernel.Get<PayService>();

            btnExit.Click += (s, e) => { Close();};

            dgvEvents.Loaded += (s, e) =>
            {
                var ItemsSource = getDataService.GetEvent();
                dgvEvents.ItemsSource = ItemsSource;
                HeadTable();
                LoadUserData();
            };

            btnBet.Click += (s, e) =>
            {
                ParceDecimal(txtSumBet.Text);
                Bet bet = new Bet(DateTime.Now
                    , ParceDecimal(txtSumBet.Text)
                    , ParceDecimal(txtelement.Text)
                    , ParceDecimal(txtSumWinBet.Text)
                    , check[0].UserId
                    , Convert.ToInt32(txtEventId.Text)
                    , txtTeam.Text);

                var conBet = betService.ConfirmBet(bet);
                if (conBet == 1)
                {
                    var pay = payService.ChangeBalance(check[0], txtSumBet.Text);
                    if (pay == 1) { MessageBox.Show($"Ваша ставка на сумму {txtSumBet.Text} принята."); }
                    else { MessageBox.Show("Ставка не принята"); }
                }
                else { MessageBox.Show("Ставка не принята"); }
            };
        }

        public void HeadTable()
        {
            dgvEvents.Columns[0].Header = "Id События";
            dgvEvents.Columns[1].Header = "Дата События";
            dgvEvents.Columns[2].Header = "Команда 1";
            dgvEvents.Columns[3].Header = "Коэф Команда 1";
            dgvEvents.Columns[4].Header = "Команда 2";
            dgvEvents.Columns[5].Header = "Коэф Команда 2";
        }

        private void LoadUserData()
        {
            txtBalance.Text = check[0].Balance.ToString();
        }

        private void DataGridCell_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridCell cell = sender as DataGridCell;
            if (!cell.IsEditing)
            {
                if (!cell.IsFocused)
                    cell.Focus();
                if (!cell.IsSelected)
                    cell.IsSelected = true;
            }
        }

        public void DgvEvents_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            NumberFormatInfo nfi = new NumberFormatInfo() { NumberDecimalSeparator = "." };
            foreach (var item in e.AddedCells)
            {
                var col = item.Column as DataGridColumn;
                txtTeam.Text = col.Header.ToString();

                var fc = col.GetCellContent(item.Item);
                var currentIem = dgvEvents.CurrentItem;
                var currentCol = dgvEvents.CurrentColumn;
                var FocusEventId = ((EventBet)currentIem).EventId;
                txtEventId.Text = FocusEventId.ToString();
                decimal MinSumBet = 100;

                if (fc is TextBlock)
                {
                    if(col.Header.ToString() == "Коэф Команда 1")
                    {
                        txtTeam.Text = ((EventBet)currentIem).Team1;
                        txtelement.Text = (fc as TextBlock).Text;
                        CheckColumn(FocusEventId);

                        if (CheckBalance() == 1)
                        {
                            if (txtSumBet.Text == "0")
                            {
                                txtSumBet.Text = MinSumBet.ToString();
                            }
                            if (decimal.TryParse(txtelement.Text, NumberStyles.Number, nfi, out decimal resultElem))
                            {
                                var coeff = resultElem;
                                if (decimal.TryParse(txtSumBet.Text, NumberStyles.Number, nfi, out decimal resultSum))
                                {
                                    var summ = resultSum;
                                    var result = (coeff * summ);
                                    txtSumWinBet.Text = result.ToString(nfi);
                                }
                            }
                        }
                    }
                    else if(col.Header.ToString() == "Коэф Команда 2")
                    {
                        txtTeam.Text = ((EventBet)currentIem).Team2;
                        txtelement.Text = (fc as TextBlock).Text;
                        CheckColumn(FocusEventId);

                        if (CheckBalance() == 1)
                        {
                            if (txtSumBet.Text == "0")
                            {
                                txtSumBet.Text = MinSumBet.ToString();
                            }
                            if (decimal.TryParse(txtelement.Text, NumberStyles.Number, nfi, out decimal resultElem))
                            {
                                var coeff = resultElem;
                                if (decimal.TryParse(txtSumBet.Text, NumberStyles.Number, nfi, out decimal resultSum))
                                {
                                    var summ = resultSum;
                                    var result = (coeff * summ);
                                    txtSumWinBet.Text = result.ToString(nfi);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void txtSumBet_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string inputSymbol = e.Text.ToString();

            if (!Regex.Match(inputSymbol, @"[0-9]").Success)
            {
                e.Handled = true;
            }
        }
        
        public void CheckColumn(int FocusEventId)
        {
            NumberFormatInfo nfi = new NumberFormatInfo() { NumberDecimalSeparator = "." };
            if (txtselect.Text.Length > 0)
            {
                if (decimal.TryParse(txtselect.Text, NumberStyles.Number, nfi, out decimal result))
                {
                    if (result != FocusEventId) txtelement.Text = result.ToString();
                }
            }
        }

        public int CheckBalance()
        {
            NumberFormatInfo nfi = new NumberFormatInfo() { NumberDecimalSeparator = "." };
            decimal UserBalance = Convert.ToDecimal(txtBalance.Text);
            decimal MinSumBet = 100;

            if (UserBalance > MinSumBet)
            {
                if(txtSumBet.Text != "")
                {
                    if (decimal.TryParse(txtSumBet.Text, NumberStyles.Number, nfi, out decimal result))
                    {
                        if (UserBalance > result)
                        {
                            txtSumBet.Text = result.ToString((nfi));
                            return 1;
                        }
                        else {MessageBox.Show("Недостаточно средств на балансе! Пополните баланс");}
                    }
                }
                MessageBox.Show("Введите сумму ставки. Минимальная ставка 100");
                txtSumBet.Text = "100";
            }
            return 2;
        }
        private decimal ParceDecimal(string str)
        {
            NumberFormatInfo nfi = new NumberFormatInfo() { NumberDecimalSeparator = "." };
           
            if (decimal.TryParse(str, NumberStyles.Number, nfi, out decimal result))
            {}
            return result;
        }
    }
}
