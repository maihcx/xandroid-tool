using System.Windows.Media;
using Wpf.Ui.Controls;

namespace XAndroid_Tool.Models
{
    public struct NavigationButton
    {
        public Type TargetPageType { get; set; }
        public Button ButtonView { get; set; }
    }
}
