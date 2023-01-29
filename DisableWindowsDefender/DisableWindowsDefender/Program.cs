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
            logging.StartLog();
            string buildVersion = version.GetBuildVersion();
            if (int.TryParse(buildVersion, out int build))
            {
                if (build < VERSION_WINDOWS_10_TP)
                {

                }
                else
                {
                   
                }
            }
            else
                logging.SendLog("Version Windows unknown", StatusLog.ERROR);
            logging.EndLog();
        }
    }
}
