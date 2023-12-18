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
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "java.exe";
                psi.Arguments = " -version";
                psi.RedirectStandardError = true;
                psi.UseShellExecute = false;

                Process pr = Process.Start(psi);
                string strOutput = pr.StandardError.ReadLine().Split(' ')[2].Replace("\"", "");
            }
            catch
            {
                return true;
            }

            return false;
        }

        private static string CommandExecute(string command)
        {
            string output = string.Empty;

                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardOutput = true;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = $"/c {command}";
                process.StartInfo = startInfo;
                process.Start();
                output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

            return output;
        }
    }
}
