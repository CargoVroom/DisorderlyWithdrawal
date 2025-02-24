﻿using System;
using System.IO;

namespace DisorderlyWithdrawal {
    public class Logger {

        private static StreamWriter LogStream;
        private static string LogFile;

        public Logger(string modDir, string logName) {
            if (LogFile == null) {
                LogFile = Path.Combine(modDir, $"{logName}.log");
            }
            if (File.Exists(LogFile)) {
                File.Delete(LogFile);
            }

            LogStream = File.AppendText(LogFile);
        }

        public void Debug(string message) { if (Mod.Config.Debug) { Info(message); } }
        public void Trace(string message) { if (Mod.Config.Trace) { Info(message); } }

        public void Info(string message) {
            string now = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
            LogStream.WriteLine($"{now} - {message}");
            LogStream.Flush();
        }

    }
}
