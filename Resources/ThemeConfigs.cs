using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Ui.Controls;

namespace XAndroid_Tool.Resources
{
    public static class ThemeConfigs
    {
        public static WindowBackdropType WindowBackdropDefault = WindowBackdropType.Mica;

        public static WindowBackdropType IWindowBackdropType { get => new WindowBackdropType(); }

        public enum IThemeType
        {
            //
            // Summary:
            //     Auto application theme.
            Auto,
            //
            // Summary:
            //     Light application theme.
            Light,
            //
            // Summary:
            //     Dark application theme.
            Dark,
            //
            // Summary:
            //     High contract application theme.
            HighContrast,
            //
            // Summary:
            //     Unknown application theme.
            Unknown,
        }
    }
}
