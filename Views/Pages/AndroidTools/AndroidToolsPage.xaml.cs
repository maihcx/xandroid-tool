using XAndroid_Tool.ViewModels.Pages.AndroidTools;

namespace XAndroid_Tool.Views.Pages.AndroidTools
{
    /// <summary>
    /// Interaction logic for AndroidToolsPage.xaml
    /// </summary>
    public partial class AndroidToolsPage : INavigableView<AndroidToolsViewModel>
    {
        public AndroidToolsViewModel ViewModel { get; }
        public AndroidToolsPage(AndroidToolsViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }
    }
}
