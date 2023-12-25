using System.Windows.Controls;
//using Wpf.Ui.Common;
using XAndroid_Tool.ControlsLookup;
using XAndroid_Tool.ViewModels.Pages.AndroidTools;

namespace XAndroid_Tool.Views.Pages.AndroidTools
{
    [GalleryPage("Overlay Tool", "Extract string resources from APK.", SymbolRegular.DeveloperBoardSearch20)]
    /// </summary>
    public partial class OverlayToolPage : INavigableView<OverlayToolViewModel>
    {
        public OverlayToolViewModel ViewModel { get; }
        public OverlayToolPage(OverlayToolViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }
    }
}
