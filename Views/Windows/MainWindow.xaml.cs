// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

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

            SharedVariable.GlobalSnackbar = snackbarService;
        }

        private void OnSourceInitialized(object? sender, EventArgs e)
        {

            ApplicationThemeManager.Apply(ThemeManagerService.GetSysApplicationTheme(), ThemeManagerService.GetBackdropType(), true);
            ViewModel.OnNavigatedTo();

            //ThemeManagerService.OnThemeChanged += (theme) =>
            //{
            //    Wpf.Ui.Appearance.Theme.Apply(theme, ThemeManagerService.GetBackdropType(), true);
            //};
        }
    }
}
