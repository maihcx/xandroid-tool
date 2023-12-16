// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System.Windows.Data;
using Wpf.Ui.Controls;
using XAndroid_Tool.Resources;
using XAndroid_Tool.Services;
using static XAndroid_Tool.Resources.ThemeConfigs;

namespace XAndroid_Tool.ViewModels.Pages
{
    public partial class SettingsViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;

        private ApplicationThemeManagerService ThemeManagerService = SharedVariable.ThemeManagerService;

        [ObservableProperty]
        private string _appVersion = String.Empty;

        [ObservableProperty]
        private IThemeType _currentTheme = IThemeType.Auto;

        [ObservableProperty]
        private Wpf.Ui.Controls.WindowBackdropType _currentMaterial = ThemeConfigs.WindowBackdropDefault;

        [ObservableProperty]
        private CollectionView _themeList;

        public void OnNavigatedTo()
        {
            if (!_isInitialized)
                InitializeViewModel();
        }

        public void OnNavigatedFrom() { }

        private void InitializeViewModel()
        {
            CurrentTheme = ThemeManagerService.GetApplicationTheme();
            AppVersion = $"XAndroid Tool - {GetAssemblyVersion()}";

            _isInitialized = true;

            ThemeManagerService.OnThemeChanged += (theme) =>
            {
                CurrentTheme = ThemeManagerService.GetApplicationTheme();
            };
        }

        private string GetAssemblyVersion()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version?.ToString()
                ?? String.Empty;
        }

        [RelayCommand]
        public void OnChangeTheme(string parameter)
        {
            switch (parameter)
            {
                case "Auto":
                    ThemeManagerService.SetApplicationTheme(ThemeConfigs.IThemeType.Auto);
                    break;

                case "Light":
                    ThemeManagerService.SetApplicationTheme(ThemeConfigs.IThemeType.Light);
                    break;

                case "Dark":
                    ThemeManagerService.SetApplicationTheme(ThemeConfigs.IThemeType.Dark);
                    break;
            }
        }


        [RelayCommand]
        private void OnChangeMaterial(string parameter)
        {
            switch (parameter)
            {
                case "material_mica":
                    if (CurrentMaterial == WindowBackdropType.Mica)
                        break;

                    CurrentMaterial = Wpf.Ui.Controls.WindowBackdropType.Mica;
                    ThemeManagerService.SetBackdropType(CurrentMaterial);

                    break;

                case "material_acrylic":
                    if (CurrentMaterial == WindowBackdropType.Acrylic)
                        break;

                    CurrentMaterial = Wpf.Ui.Controls.WindowBackdropType.Acrylic;
                    ThemeManagerService.SetBackdropType(CurrentMaterial);

                    break;
            }

            ThemeConfigs.WindowBackdropDefault = CurrentMaterial;
        }
    }
}
