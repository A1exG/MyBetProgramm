using MyBetService;
using Ninject;
using System.Windows;

namespace MyBetView.Ui
{
    public partial class HistoryEventUi : Window
    {
        public HistoryEventUi()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();

            IKernel kernel = new StandardKernel();
            GetDataService getDataService = kernel.Get<GetDataService>();

            dgvHistory.Loaded += (s, e) =>
            {
                var ItemsSource = getDataService.GetHistories();
                dgvHistory.ItemsSource = ItemsSource;
                HeadTable();
            };

            btnExit.Click += (s, e) => {Close();};
        }
        public void HeadTable()
        {
            dgvHistory.Columns[0].Header = "Id События";
            dgvHistory.Columns[1].Header = "Дата События";
            dgvHistory.Columns[2].Header = "Команда 1";
            dgvHistory.Columns[3].Header = "Коэф Команда 1";
            dgvHistory.Columns[4].Header = "Команда 2";
            dgvHistory.Columns[5].Header = "Коэф Команда 2";
            dgvHistory.Columns[6].Header = "Победитель";
            dgvHistory.Columns[7].Header = "Статус";
        }
    }
}
