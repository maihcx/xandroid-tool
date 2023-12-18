// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System.Collections.Generic;
using System.Windows.Media;
using Wpf.Ui.Common;
using Wpf.Ui.Controls;
using XAndroid_Tool.Models;

namespace XAndroid_Tool.ViewModels.Pages
{
    public partial class DashboardViewModel : ObservableObject
    {
        private bool _isInitialized = false;

        [ObservableProperty]
        private IEnumerable<NavigationButton> _pageButtons;

        [ObservableProperty]
        private ICollection<NavigationCard> _navigationCards;

        public void OnNavigatedTo()
        {
            if (!_isInitialized)
                InitializeViewModel();
        }

        private void InitializeViewModel()
        {   
            _isInitialized = true;

            //List<NavigationButton> _PageButtons = new List<NavigationButton>();
            //_PageButtons.Add(new NavigationButton
            //{
            //    ButtonView = new Button
            //    {
            //        Content = "Android Tool",
            //        Icon = new SymbolIcon { Symbol = SymbolRegular.BoxToolbox24 }
            //    },
            //    TargetPageType = typeof(OverlayToolPage)
            //}
            //);

            //PageButtons = _PageButtons;

            var _NavigationCards = new List<NavigationCard>();
            _NavigationCards.Add(new NavigationCard {
                Name = "Overlay Tool",
                Icon = SymbolRegular.DeveloperBoardSearch20,
                Description = "No Desc",
                PageType = typeof(Views.Pages.AndroidTools.OverlayToolPage)
            });


            NavigationCards = _NavigationCards;
        }

    }
}
