// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System.Collections.ObjectModel;
using Wpf.Ui.Common;
using Wpf.Ui.Controls;
using XAndroid_Tool.Services;
using XAndroid_Tool.Views.Pages;
using XAndroid_Tool.Views.Pages.AndroidTools;

namespace XAndroid_Tool.ViewModels.Windows
{
    public partial class MainWindowViewModel : ObservableObject
    {
        private bool _isInitialized = false;
        public void OnNavigatedTo()
        {
            if (!_isInitialized)
                InitializeViewModel();
        }

        private void InitializeViewModel()
        {
            _isInitialized = true;

            //CommandService.CheckJavaAvailable();
        }

        [ObservableProperty]
        private string _applicationTitle = "XAndroid Tool";

        [ObservableProperty]
        private ObservableCollection<object> _menuItems = new()
        {
            new NavigationViewItem("Home", SymbolRegular.Home24, typeof(DashboardPage)),
            new NavigationViewItem("Android Tools", SymbolRegular.BoxToolbox24, typeof(AndroidToolsPage))
            {
                MenuItems = new object[]
                {
                    new NavigationViewItem("Overlay Tool", SymbolRegular.DeveloperBoardSearch20, typeof(OverlayToolPage)),
                }
            }
        };

        [ObservableProperty]
        private ObservableCollection<object> _footerMenuItems = new()
        {
            new NavigationViewItem("Settings", SymbolRegular.Settings24, typeof(SettingsPage))
        };

        [ObservableProperty]
        private ObservableCollection<MenuItem> _trayMenuItems = new()
        {
            new MenuItem { Header = "Home", Tag = "tray_home" }
        };
    }
}
