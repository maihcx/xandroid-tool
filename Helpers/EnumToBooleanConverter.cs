// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System.Globalization;
using System.Windows.Data;

namespace XAndroid_Tool.Helpers
{
    internal class EnumToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is not String enumString)
            {
                throw new ArgumentException("ExceptionEnumToBooleanConverterParameterMustBeAnEnumName");
            }

            //if (!Enum.IsDefined(typeof(Wpf.Ui.Appearance.ThemeType), value) && 
            //    !Enum.IsDefined(typeof(Wpf.Ui.Controls.WindowBackdropType), value))
            //{
            //    throw new ArgumentException("ExceptionEnumToBooleanConverterValueMustBeAnEnum");
            //}

            object enumValue;
            if (value is Wpf.Ui.Appearance.ThemeType)
            {
                enumValue = Enum.Parse(typeof(Wpf.Ui.Appearance.ThemeType), enumString);
                return enumValue.Equals(value);
            }
            else if (value is Wpf.Ui.Controls.WindowBackdropType)
            {
                enumValue = Enum.Parse(typeof(Wpf.Ui.Controls.WindowBackdropType), enumString);
                return enumValue.Equals(value);
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is not String enumString)
            {
                throw new ArgumentException("ExceptionEnumToBooleanConverterParameterMustBeAnEnumName");
            }

            return Enum.Parse(typeof(Wpf.Ui.Appearance.ThemeType), enumString);
        }
    }
}
