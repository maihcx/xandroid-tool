// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System.Collections.ObjectModel;
using XAndroid_Tool.ControlsLookup;
using XAndroid_Tool.Models;
using XAndroid_Tool.Views.Pages.AndroidTools;

namespace XAndroid_Tool.ViewModels.Pages.AndroidTools;

public partial class AndroidToolsViewModel : ObservableObject
{
    [ObservableProperty]
    private ICollection<NavigationCard> _navigationCards = new ObservableCollection<NavigationCard>(
        ControlPages
            .FromNamespace(typeof(AndroidToolsPage).Namespace!)
            .Select(
                x =>
                    new NavigationCard()
                    {
                        Name = x.Name,
                        Icon = x.Icon,
                        Description = x.Description,
                        PageType = x.PageType
                    }
            )
    );
}
