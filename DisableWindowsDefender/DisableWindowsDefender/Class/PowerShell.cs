using System;
using System.Diagnostics;

namespace DisableWindowsDefender.Class
{
    internal class PowerShell
    {
        private readonly Logging logging = new Logging();
        static PowerShell() { }
        internal void SendPowershellCmd(in string command)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "powershell",
                    Arguments = $"{command}",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    Verb = "runas",
                    CreateNoWindow = true,
                    UseShellExecute = true,
                }).WaitForExit();
                logging.SendLog($"Success complete turn off {command}");
            }
            catch (Exception ex)
            {
                logging.SendLog($"{ex.Message}", StatusLog.ERROR);
            }
        }
    }
}
