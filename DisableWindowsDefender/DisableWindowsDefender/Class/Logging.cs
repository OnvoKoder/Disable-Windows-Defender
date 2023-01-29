using System;
using System.IO;

namespace DisableWindowsDefender.Class
{
    internal class Logging
    {
        private readonly string file = "log.log";

        internal void StartLog()
        {
            using (StreamWriter writer = new StreamWriter(file, true))
            {
                for (int i = 0; i < 180; i++)
                    writer.Write("-");
                writer.WriteLine($"{Environment.NewLine}|{StatusLog.NOTIFY}| {DateTime.Now} Program start");
            }
        }
        internal void SendLog(in string message, in StatusLog status = StatusLog.ACTION)
        {
            using (StreamWriter writer = new StreamWriter(file, true))
                writer.WriteLine($"{Environment.NewLine}|{status}| {DateTime.Now} {message}");
        }
        internal void EndLog()
        {
            using (StreamWriter writer = new StreamWriter(file, true))
            {
                writer.WriteLine($"{Environment.NewLine}|{StatusLog.NOTIFY}| {DateTime.Now} Program end");
                for (int i = 0; i < 180; i++)
                    writer.Write("-");
                writer.WriteLine();
            }
        }

    }
}
}
