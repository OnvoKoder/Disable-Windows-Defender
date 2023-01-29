using DisableWindowsDefender.Class;

namespace DisableWindowsDefender
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int VERSION_WINDOWS_10_TP = 18362; //Tamper Protection appeared in Version 1903. If your version Windows 1903 or later - turn off tamper protection yourself.
            BuildVersion version = new BuildVersion();
            Logging logging = new Logging();
            PowerShell powershell = new PowerShell();
            RegEdit regedit = new RegEdit();
            logging.StartLog();
            string buildVersion = version.GetBuildVersion();
            if (int.TryParse(buildVersion, out int build))
            {
                if (build < VERSION_WINDOWS_10_TP)
                {
                    regedit.RegistryKeyChange(@"SOFTWARE\Policies\Microsoft\Windows Defender", "DisableAntiSpyware", "1");
                    regedit.RegistryKeyChange(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection", "DisableBehaviorMonitoring", "1");
                    regedit.RegistryKeyChange(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection", "DisableOnAccessProtection", "1");
                    regedit.RegistryKeyChange(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection", "DisableScanOnRealtimeEnable", "1");
                }
                else
                {
                    powershell.SendPowershellCmd("Set-MpPreference -DisableIntrusionPreventionSystem $true -DisableIOAVProtection $true -DisableRealtimeMonitoring $true");
                    powershell.SendPowershellCmd("Set-MpPreference -DisableScriptScanning $true");
                    powershell.SendPowershellCmd("Set-MpPreference -EnableControlledFolderAccess Disabled");
                    powershell.SendPowershellCmd("Set-MpPreference -EnableNetworkProtection AuditMode -Force -MAPSReporting Disabled -SubmitSamplesConsent NeverSend");
                }
            }
            else
                logging.SendLog("Version Windows unknown", StatusLog.ERROR);
            logging.EndLog();
        }
    }
}
