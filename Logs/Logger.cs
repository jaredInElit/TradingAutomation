using System;
using System.IO;

namespace TradingAutomation.Logs
{
    public static class Logger
    {
        private static string logFile = "trade_log.txt";

        public static void Initialize()
        {
            if (!File.Exists(logFile))
                File.Create(logFile).Dispose();
        }

        public static void Log(string message)
        {
            using (StreamWriter writer = File.AppendText(logFile))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }
    }
}