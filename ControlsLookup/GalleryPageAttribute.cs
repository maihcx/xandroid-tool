// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System.Xml.Linq;
using Wpf.Ui.Common;

namespace XAndroid_Tool.ControlsLookup;

[AttributeUsage(AttributeTargets.Class)]
class GalleryPageAttribute : Attribute
{
    public string Name { get; }
    public string Description { get; }
    public SymbolRegular Icon { get; }

    public GalleryPageAttribute(string description, SymbolRegular icon)
    {
        Description = description;
        Icon = icon;
    }

    public GalleryPageAttribute(string name, string description, SymbolRegular icon)
    {
        Name = name;
        Description = description;
        Icon = icon;
    }
}
