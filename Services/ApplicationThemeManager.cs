using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Ui.Controls;
using XAndroid_Tool.Resources;
using Wpf.Ui.Appearance;
using static XAndroid_Tool.Resources.ThemeConfigs;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace XAndroid_Tool.Services
{
    public class ApplicationThemeManagerService
    {
        public WindowBackdropType GetBackdropType()
        {
            return (WindowBackdropType)Enum.Parse(
                typeof(WindowBackdropType), 
                UserDataStored.GetValue("IWindowBackdropType")
            );
        }

        public delegate void ThemeChangedHandle(ThemeType theme);

        public event ThemeChangedHandle OnThemeChanged;

        private ThemeType ApplicationSysTheme = ThemeType.Unknown;

        public ApplicationThemeManagerService()
        {
            Theme.Changed += (ThemeType currentTheme, System.Windows.Media.Color systemAccent) =>
            {
                if (Theme.IsMatchedDark() || (!Theme.IsMatchedLight() && currentTheme == ThemeType.Light))
                {
                    ApplicationSysTheme = ThemeType.Dark;
                }
                else if (Theme.IsMatchedLight() || (!Theme.IsMatchedDark() && currentTheme == ThemeType.Dark))
                {
                    ApplicationSysTheme = ThemeType.Light;
                }
            };
        }

        public void SetBackdropType(WindowBackdropType _WindowBackdropType)
        {
            UserDataStored.SetValue("IWindowBackdropType", _WindowBackdropType.ToString());

            Wpf.Ui.Appearance.Theme.Apply(GetSysApplicationTheme(), _WindowBackdropType, true);
        }

        public IThemeType GetApplicationTheme()
        {
            try
            {
                return (IThemeType)Enum.Parse(
                    typeof(IThemeType),
                    UserDataStored.GetValue("IThemeType")
                );
            }
            catch
            {
                return IThemeType.Auto;
            }
        }

        public ThemeType GetSysApplicationTheme()
        {
            ThemeType _ThemeType;
            Wpf.Ui.Appearance.Watcher.UnWatch();
            if (UserDataStored.GetValue("IThemeType") == "Auto")
            {
                _ThemeType = ApplicationSysTheme;
                Wpf.Ui.Appearance.Watcher.Watch(SharedVariable.MainWindow, GetBackdropType(), true);
            }
            else
            {
                _ThemeType = (ThemeType)Enum.Parse(
                    typeof(ThemeType),
                    UserDataStored.GetValue("IThemeType")
                );
            }

            return _ThemeType;
        }

        public void SetApplicationTheme(IThemeType _IThemeType) 
        { 
            UserDataStored.SetValue("IThemeType", _IThemeType.ToString());
            string valS = _IThemeType.ToString();
            if (_IThemeType == IThemeType.Auto)
            {
                Wpf.Ui.Appearance.Watcher.Watch(SharedVariable.MainWindow, GetBackdropType(), true);
            }
            else
            {
                Wpf.Ui.Appearance.Theme.Apply(GetSysApplicationTheme(), GetBackdropType(), true);
            }
            OnThemeChanged?.Invoke(this.GetSysApplicationTheme());
        }
    }
}
