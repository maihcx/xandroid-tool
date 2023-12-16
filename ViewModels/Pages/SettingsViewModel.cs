// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using Wpf.Ui.Controls;
using XAndroid_Tool.Resources;

namespace XAndroid_Tool.ViewModels.Pages
{
    public partial class SettingsViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;

        [ObservableProperty]
        private string _appVersion = String.Empty;

        [ObservableProperty]
        private Wpf.Ui.Appearance.ThemeType _currentTheme = Wpf.Ui.Appearance.ThemeType.Unknown;

        [ObservableProperty]
        private Wpf.Ui.Controls.WindowBackdropType _currentMaterial = ThemeConfigs.WindowBackdropDefault;

        public void OnNavigatedTo()
        {
            if (!_isInitialized)
                InitializeViewModel();
        }

        public void OnNavigatedFrom() { }

        private void InitializeViewModel()
        {
            CurrentTheme = Wpf.Ui.Appearance.Theme.GetAppTheme();
            AppVersion = $"XAndroid Tool - {GetAssemblyVersion()}";

            _isInitialized = true;
        }

        private string GetAssemblyVersion()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version?.ToString()
                ?? String.Empty;
        }

        [RelayCommand]
        private void OnChangeTheme(string parameter)
        {
            switch (parameter)
            {
                case "theme_light":
                    if (CurrentTheme == Wpf.Ui.Appearance.ThemeType.Light)
                        break;

                    Wpf.Ui.Appearance.Theme.Apply(Wpf.Ui.Appearance.ThemeType.Light, ThemeConfigs.WindowBackdropDefault, true);
                    CurrentTheme = Wpf.Ui.Appearance.ThemeType.Light;

                    break;

                default:
                    if (CurrentTheme == Wpf.Ui.Appearance.ThemeType.Dark)
                        break;

                    Wpf.Ui.Appearance.Theme.Apply(Wpf.Ui.Appearance.ThemeType.Dark, ThemeConfigs.WindowBackdropDefault, true);
                    CurrentTheme = Wpf.Ui.Appearance.ThemeType.Dark;

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
                    Wpf.Ui.Appearance.Theme.Apply(CurrentTheme, CurrentMaterial, true);

                    break;

                case "material_acrylic":
                    if (CurrentMaterial == WindowBackdropType.Acrylic)
                        break;

                    CurrentMaterial = Wpf.Ui.Controls.WindowBackdropType.Acrylic;
                    Wpf.Ui.Appearance.Theme.Apply(CurrentTheme, CurrentMaterial, true);

                    break;
            }

            ThemeConfigs.WindowBackdropDefault = CurrentMaterial;
        }
    }
}
