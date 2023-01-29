using Microsoft.Win32;
using System.Security.AccessControl;

namespace DisableWindowsDefender.Class
{
    internal class RegEdit
    {
        private readonly Logging logging = new Logging();
        static RegEdit() { }
        internal void RegistryKeyChange(in string key, in string name, in string value)
        {
            using (RegistryKey regKey = Registry.LocalMachine.OpenSubKey(key, RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.FullControl))
            {
                if (regKey == null)
                    Registry.LocalMachine.CreateSubKey(key).SetValue(name, value, RegistryValueKind.DWord);
                else
                    regKey.SetValue(name, value, RegistryValueKind.DWord);
                logging.SendLog($"Success complete turn off {name}");
            }
        }
    }
}
