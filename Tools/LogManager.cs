using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public static class LogManager
    {
        private const string LogFolderName = "Log";
        public static string GetFolderPath()
        {
            return Path.Combine(LogFolderName, DateTime.Now.ToString("yyyy-MM"));
        }
        public static string GetFilePath()
        {
            string fileName = DateTime.Now.ToString("yyyy-MM-dd")+".txt";
            return Path.Combine(GetFolderPath(), fileName);
        }

        public static void WriteToLog(string projectName,string functionName,string message)
        {
            Directory.CreateDirectory(GetFolderPath());
            string line = $"{DateTime.Now}\t{projectName}.{functionName}:\t{message}";
            File.AppendAllText(GetFilePath(), line + Environment.NewLine);
        }
        public static void CleanOldLogs()
        {
            if (!Directory.Exists(LogFolderName))
                return;
            DateTime now = DateTime.Now;
            DateTime cutoff = new DateTime(now.Year, now.Month, 1).AddMonths(-2);
            foreach(string folder in Directory.GetDirectories(LogFolderName))
            {
                string name = Path.GetFileName(folder);
                if(DateTime.TryParseExact(name,"yyyy-MM",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime folderDate))
                {
                    if (folderDate < cutoff)
                        Directory.Delete(folder, true);
                }

            }


        }
    }
}
