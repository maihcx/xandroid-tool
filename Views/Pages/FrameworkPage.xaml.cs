using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using XAndroid_Tool.ViewModels.Pages;

namespace XAndroid_Tool.Views.Pages
{
    /// <summary>
    /// Interaction logic for FrameworkPage.xaml
    /// </summary>
    public partial class FrameworkPage : INavigableView<FrameworkViewModel>
    {
        public FrameworkViewModel ViewModel { get; }

        public FrameworkPage(FrameworkViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }
    }
}
