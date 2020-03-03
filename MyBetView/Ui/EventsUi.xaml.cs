using MyBetModel.Model;
using MyBetService;
using Ninject;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyBetView.Ui
{
    public partial class EventsUi : Window
    {
        public EventsUi()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void dgvEvents_Loaded(object sender, RoutedEventArgs e)
        {
            IKernel kernel = new StandardKernel();
            GetDataService getDataService = kernel.Get<GetDataService>();

            var ItemsSource = getDataService.GetEvent();
            dgvEvents.ItemsSource = ItemsSource;
            HeadTable();
            
        }

        private void dgvEvents_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            EventBet eventBet = dgvEvents.SelectedItem as EventBet;
            EventBet evBet = dgvEvents.SelectedCells as EventBet;

            string a = eventBet.EventId.ToString();
        }

        public void HeadTable()
        {
            dgvEvents.Columns[0].Header = "Id События";
            dgvEvents.Columns[1].Header = "Дата События";
            dgvEvents.Columns[2].Header = "Команда 1";
            dgvEvents.Columns[3].Header = "Коэффицент команды 1";
            dgvEvents.Columns[4].Header = "Команда 2";
            dgvEvents.Columns[5].Header = "Коэффицент команды 2";
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
            foreach (var item in e.AddedCells)
            {
                var col = item.Column as DataGridColumn;
                var colonka = col.Header.ToString();

                var fc = col.GetCellContent(item.Item);
                var currentIem = dgvEvents.CurrentItem;
                var FocusEventId = ((EventBet)currentIem).EventId;
                var focusEvent = FocusEventId.ToString();

                if (fc is TextBlock)
                {
                    var content = (fc as TextBlock).Text;
                }
            }
        }
    }
}
