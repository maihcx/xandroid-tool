// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System.Collections.ObjectModel;
using System.Diagnostics;
//using Wpf.Ui.Common;
using Wpf.Ui.Controls;
using XAndroid_Tool.Lib.ApkTool;
using XAndroid_Tool.Lib.Java;
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

        private async void InitializeViewModel()
        {
            _isInitialized = true;
            try
            {
                var asyncVoid = async () =>
                {
                    Apktool apktool = new Apktool(JavaUtils.GetJavaPath(), MainAssembly.APKTOOL_PATH);
                    string javaVersion = apktool.GetJavaVersion();
                    string apktoolVersion = apktool.GetVersion();
                    if (javaVersion == string.Empty)
                    {
                        MessengerService.ShowSnackbar("Error", "Missing java, please install java 8 to continues", ControlAppearance.Danger, TimeSpan.FromSeconds(15));
                    }
                    else
                    {
                        ControlAppearance controlAppearance = ControlAppearance.Success;
                        if (apktoolVersion == string.Empty)
                        {
                            controlAppearance = ControlAppearance.Caution;
                            apktoolVersion = $"MISSING APKTOOL, PLEASE INSTALL APK TOOL!!!\nLOCATION: {MainAssembly.RES_PATH}";
                        }
                        else
                        {
                            apktoolVersion = $"Version: {apktoolVersion}";
                        }
                        MessengerService.ShowSnackbar("System Info", $"JAVA:\n{javaVersion}\n\n APKTOOL:\n{apktoolVersion}", controlAppearance, TimeSpan.FromSeconds(15));
                    }
                };

                asyncVoid();
            }
            catch (Exception ex)
            {
                MessengerService.ShowSnackbar("System Internal Error", ex.ToString(), ControlAppearance.Danger, TimeSpan.FromSeconds(15));
            }
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
            },
            new NavigationViewItem("Framework", SymbolRegular.WindowDevEdit20, typeof(FrameworkPage))
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
