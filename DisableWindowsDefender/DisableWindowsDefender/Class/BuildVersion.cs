using Microsoft.Win32;

namespace DisableWindowsDefender.Class
{
    internal class BuildVersion
    {
        private readonly Logging logging = new Logging();
        internal string GetBuildVersion()
        {
            string key = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
            using (RegistryKey regKey = Registry.LocalMachine.OpenSubKey(key))
            {
                if (regKey.GetValue("CurrentBuild") != null)
                {
                    logging.SendLog($"Success get your version windows : your version {regKey.GetValue("CurrentBuild")}");
                    return regKey.GetValue("CurrentBuild").ToString();
                }
                else
                {
                    logging.SendLog("Appear fail with getting data about version windows. Does't get information", StatusLog.ERROR);
                    return "INVALID";
                }
            }
        }
    }
}
