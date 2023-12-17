// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System.Windows.Controls;
using Wpf.Ui.Controls;
using XAndroid_Tool.Resources;
using XAndroid_Tool.Services;
using XAndroid_Tool.ViewModels.Pages;

namespace XAndroid_Tool.Views.Pages
{
    public partial class SettingsPage : INavigableView<SettingsViewModel>
    {
        public SettingsViewModel ViewModel { get; }

        private ApplicationThemeManagerService ThemeManagerService = SharedVariable.ThemeManagerService;

        public SettingsPage(SettingsViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();

            cbbThemes.SelectedIndex = (int)ThemeManagerService.GetApplicationTheme();
            cbbThemes.SelectionChanged += cbbThemes_SelectionChanged;

            cbbMaterial.SelectedIndex = (int)ThemeManagerService.GetBackdropType();
            cbbMaterial.SelectionChanged += cbbMaterial_SelectionChanged;
        }

        private void cbbThemes_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string themeTake = ((ComboBoxItem)((ComboBox)sender).SelectedItem).Content.ToString() ?? "Auto";
            ViewModel.OnChangeTheme(themeTake);
        }

        private void cbbMaterial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string materialTake = ((ComboBoxItem)((ComboBox)sender).SelectedItem).Content.ToString() ?? "Mica";
            ViewModel.OnChangeMaterial(materialTake);
        }
    }
}
