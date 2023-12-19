using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Ui.Controls;
using XAndroid_Tool.Resources;

namespace XAndroid_Tool.Services
{
    public static class MessengerService
    {
        public static async void ShowSnackbar(string title, string content, ControlAppearance controlAppearance)
        {
            ShowSnackbar(title, content, controlAppearance, null, default);
        }

        public static async void ShowSnackbar(string title, string content, ControlAppearance controlAppearance, TimeSpan timeSpan = default)
        {
            ShowSnackbar(title, content, controlAppearance, null, timeSpan);
        }

        public static async void ShowSnackbar(string title, string content, ControlAppearance controlAppearance, IconElement icon = null)
        {
            ShowSnackbar(title, content, controlAppearance, icon, default);
        }

        public static async void ShowSnackbar(string title, string content, ControlAppearance controlAppearance, IconElement icon = null, TimeSpan timeSpan = default)
        {
            SharedVariable.GlobalSnackbar.Show(title, content, controlAppearance, icon, timeSpan);
        }
    }
}
