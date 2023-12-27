using Wpf.Ui.Controls;
using XAndroid_Tool.Resources;
using static XAndroid_Tool.Resources.ThemeConfigs;

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

        public bool IsWatcher {  get; set; }

        public ApplicationThemeManagerService()
        {
            //ApplicationThemeManager.Changed += (ThemeType currentTheme, System.Windows.Media.Color systemAccent) =>
            //{
                //ThemeType themeType = Wpf.Ui.Appearance.ApplicationThemeManager.GetAppTheme();
                //ApplicationSysTheme = themeService.GetTheme();

                //if (ApplicationThemeManager.IsMatchedDark() || (!ApplicationThemeManager.IsMatchedLight() && currentTheme == ThemeType.Light))
                //{
                //    ApplicationSysTheme = ThemeType.Dark;
                //}
                //else if (ApplicationThemeManager.IsMatchedLight() || (!ApplicationThemeManager.IsMatchedDark() && currentTheme == ThemeType.Dark))
                //{
                //    ApplicationSysTheme = ThemeType.Light;
                //}
            //};
        }

        public void SetBackdropType(WindowBackdropType _WindowBackdropType)
        {
            UserDataStored.SetValue("IWindowBackdropType", _WindowBackdropType.ToString());

            ThemeApply(GetSysApplicationTheme(), _WindowBackdropType);
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
            ThemeType _ThemeType = ThemeType.Unknown;
            if (UserDataStored.GetValue("IThemeType") == "Auto")
            {
                ApplicationThemeManager.ApplySystemTheme();
                _ThemeType = ApplicationThemeManager.GetAppTheme();
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
            if (GetApplicationTheme() == _IThemeType) return;

            UnWatch();
            UserDataStored.SetValue("IThemeType", _IThemeType.ToString());
            ThemeType applicationTheme = GetSysApplicationTheme();
            WindowBackdropType windowBackdropType = GetBackdropType();

            if (_IThemeType == IThemeType.Auto)
            {
                Watch(applicationTheme, windowBackdropType, true);
            }
            else
            {
                ThemeApply(applicationTheme, windowBackdropType);
            }
            OnThemeChanged?.Invoke(applicationTheme);
        }

        public void Watch(ThemeType applicationTheme = ThemeType.Unknown, WindowBackdropType windowBackdrop = WindowBackdropType.Mica, bool updateAccents = true, bool forceBackgroundReplace = false)
        {
            if (!IsWatcher)
            {
                ThemeApply(applicationTheme, windowBackdrop);
                Watcher.Watch(SharedVariable.MainWindow, windowBackdrop, updateAccents, forceBackgroundReplace);
                IsWatcher = true;
            }
        }

        private void ThemeApply(ThemeType applicationTheme = ThemeType.Light, WindowBackdropType backgroundEffect = WindowBackdropType.Mica)
        {
            ApplicationThemeManager.Apply(applicationTheme, backgroundEffect, true, true);
        }

        public void UnWatch()
        {
            if (IsWatcher)
            {
                Watcher.UnWatch(SharedVariable.MainWindow);
                IsWatcher = false;
            }
        }
    }
}
