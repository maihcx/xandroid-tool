using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAndroid_Tool.Services
{
    public static class CommandService
    {
        public static bool CheckJavaAvailable()
        {
            try
            {
                //ProcessStartInfo psi = new ProcessStartInfo();
                //psi.WindowStyle = ProcessWindowStyle.Hidden;
                //psi.CreateNoWindow = true;
                //psi.FileName = "java.exe";
                //psi.Arguments = " apktool";
                //psi.RedirectStandardError = true;
                //psi.UseShellExecute = false;

                //Process proc = Process.Start(psi);
                //string strOutput = proc.StandardError.ReadToEnd();
                //proc.WaitForExit();

                //CommandExecute("apktool");

                return true;
            }
            catch
            {
                return false;
            }
        }

        private static void JavaCommandExcute(string command)
        {

        }

        private static string CommandExecute(string command)
        {
            string output = string.Empty;
            const string ipAddress = "127.0.0.1";
            Process process = new Process
            {
                StartInfo =
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    FileName = "cmd.exe",
                    Arguments = $"/C {command}"
                }
            };
            process.Start();
            //process.WaitForExit();
            if (process.HasExited)
            {
                output = process.StandardOutput.ReadToEnd();
            }
            return output;
        }
    }
}
