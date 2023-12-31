using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Ui.Controls;
using XAndroid_Tool.Services;
using static XAndroid_Tool.Services.ApplicationThemeManagerService;

namespace XAndroid_Tool.Resources
{
    public static class SharedVariable
    {
        public static ApplicationThemeManagerService ThemeManagerService;
        public static Window MainWindow;
        public static ISnackbarService GlobalSnackbar;

        private static bool _IsAutoHideNavPanel = UserDataStored.GetValueBool("IsAutoHideNavPanel");
        public static bool IsAutoHideNavPanel {
            get { return _IsAutoHideNavPanel; }
            set {
                if (_IsAutoHideNavPanel == value) return;

                _IsAutoHideNavPanel = value;
                OnAutoHideNavChanged?.Invoke(value);
            }
        }
        public delegate void AutoHideNavPanelChanged(bool state);
        public static event AutoHideNavPanelChanged OnAutoHideNavChanged;

        //public static Apktool apkTool;
    }
}
