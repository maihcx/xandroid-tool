using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Ui.Controls;
using XAndroid_Tool.Services;

namespace XAndroid_Tool.Resources
{
    public static class SharedVariable
    {
        public static ApplicationThemeManagerService ThemeManagerService;
        public static Window MainWindow;
        public static ISnackbarService GlobalSnackbar;

        //public static Apktool apkTool;
    }
}
