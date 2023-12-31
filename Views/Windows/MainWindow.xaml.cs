// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System.Diagnostics;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;
using XAndroid_Tool.Resources;
using XAndroid_Tool.Services;
using XAndroid_Tool.Services.Contracts;
using XAndroid_Tool.ViewModels.Windows;

namespace XAndroid_Tool.Views.Windows
{
    public partial class MainWindow : IWindow
    {
        public MainWindowViewModel ViewModel { get; }

        public ApplicationThemeManagerService ThemeManagerService { get; }

        public MainWindow(
            MainWindowViewModel viewModel,
            INavigationService navigationService,
            IServiceProvider serviceProvider,
            ISnackbarService snackbarService,
            IContentDialogService contentDialogService
        )
        {
            SharedVariable.MainWindow = this;

            ViewModel = viewModel;
            ThemeManagerService = new ApplicationThemeManagerService();
            SharedVariable.ThemeManagerService = ThemeManagerService;
            DataContext = this;

            ThemeManagerService.Watch();
            InitializeComponent();

            navigationService.SetNavigationControl(NavigationView);
            snackbarService.SetSnackbarPresenter(SnackbarPresenter);
            contentDialogService.SetContentPresenter(RootContentDialog);

            NavigationView.SetServiceProvider(serviceProvider);

            this.SourceInitialized += OnSourceInitialized;
            this.Closing += MainWindow_Closing;
            if (SharedVariable.IsAutoHideNavPanel)
            {
                this.SizeChanged += MainWindow_SizeChanged;
            }
            SharedVariable.OnAutoHideNavChanged += SharedVariable_OnAutoHideNavChanged;

            SharedVariable.GlobalSnackbar = snackbarService;

            RestoreWindow();
        }

        private void SharedVariable_OnAutoHideNavChanged(bool state)
        {
            if (state) {
                this.SizeChanged += MainWindow_SizeChanged;
                MainWindow_SizeChanged(null, null);
            }
            else
            {
                this.SizeChanged -= MainWindow_SizeChanged;
                NavigationView.IsPaneOpen = true;
            }
        }

        public void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double size_width = this.Width;
            if (size_width < 900 && NavigationView.IsPaneOpen)
            {
                NavigationView.IsPaneOpen = false;
            }
            else if (size_width >= 900 && !NavigationView.IsPaneOpen)
            {
                NavigationView.IsPaneOpen = true;
            }
        }

        private void MainWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveWindow();
        }

        private void OnSourceInitialized(object? sender, EventArgs e)
        {

            ApplicationThemeManager.Apply(ThemeManagerService.GetSysApplicationTheme(), ThemeManagerService.GetBackdropType(), true);
            ViewModel.OnNavigatedTo();

            NavigationView.IsPaneOpen = false;

            //ThemeManagerService.OnThemeChanged += (theme) =>
            //{
            //    Wpf.Ui.Appearance.Theme.Apply(theme, ThemeManagerService.GetBackdropType(), true);
            //};
        }

        private void SaveWindow()
        {
            UserDataStored.SetValue("IsWindow_Maximized", this.WindowState == WindowState.Maximized);
            UserDataStored.SetValue("Window_Top", this.Top);
            UserDataStored.SetValue("Window_Left", this.Left);
            UserDataStored.SetValue("Window_Width", this.Width);
            UserDataStored.SetValue("Window_Height", this.Height);
            UserDataStored.SetValue("StartUpCode", "xv2");
        }

        private void RestoreWindow()
        {
            string startUpCode = UserDataStored.GetValue("StartUpCode");
            if (startUpCode != "xv1")
            {
                this.WindowStartupLocation = WindowStartupLocation.Manual;

                this.Top = UserDataStored.GetValueDouble("Window_Top");
                this.Left = UserDataStored.GetValueDouble("Window_Left");
                this.Width = UserDataStored.GetValueDouble("Window_Width");
                this.Height = UserDataStored.GetValueDouble("Window_Height");

                if (UserDataStored.GetValueBool("IsWindow_Maximized"))
                {
                    this.WindowState = WindowState.Maximized;
                }
                else
                {
                    this.WindowState = WindowState.Normal;
                }
            }
            else
            {
                this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            }
        }
    }
}
