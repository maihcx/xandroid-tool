using Wpf.Ui.Controls;
using XAndroid_Tool.ViewModels.Pages;

namespace XAndroid_Tool.Views.Pages
{
    public partial class DashboardPage : INavigableView<DashboardViewModel>
    {
        public DashboardViewModel ViewModel { get; }

        public DashboardPage(DashboardViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();

            ViewModel.OnNavigatedTo();
        }
    }
}
