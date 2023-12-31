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

        public static bool GetValueBool(string key)
        {
            return Convert.ToBoolean(GetValue(key));
        }

        public static double GetValueDouble(string key)
        {
            return Convert.ToDouble(GetValue(key));
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

        public static bool SetValue(string key, bool value)
        {
            try
            {
                Properties.Settings.Default[key] = value;
                Properties.Settings.Default.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool SetValue(string key, double value)
        {
            try
            {
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
