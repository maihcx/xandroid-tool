using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAndroid_Tool.Resources
{
    public static class UserDataStored
    {
        public static string GetValue(string key)
        {
            return Properties.Settings.Default[key].ToString() ?? string.Empty;
        }

        public static bool SetValue(string key, string value)
        {
            try {
                Properties.Settings.Default[key] = value;
                Properties.Settings.Default.Save();
                return true; 
            }
            catch
            {
                return false;
            }
        }

        public static void Reset()
        {
            Properties.Settings.Default.Reset();
        }

        public static void Reload()
        {
            Properties.Settings.Default.Reload();
        }
    }
}
