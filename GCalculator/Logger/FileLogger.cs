using System;
using System.Configuration;
using System.IO;
using Logger.Interfaces;
using Logger.Utils;


namespace Logger
{
    internal class FileLogger : ILogger
    {
        private readonly string _logPath = ConfigReader.FileLogPath;
        private readonly string _logNameFormat = ConfigReader.LogNameFormat;

        public void Info(string message)
        {
            WriteToLog(LogMessageTypeEnum.Info, message);
        }

        public void Warn(string message)
        {
            WriteToLog(LogMessageTypeEnum.Warn, message);
        }

        public void Error(string message)
        {
            WriteToLog(LogMessageTypeEnum.Error, message);
        }

        public void Debug(string message)
        {
            WriteToLog(LogMessageTypeEnum.Debug, message);
        }

        public void Fatal(string message)
        {
            WriteToLog(LogMessageTypeEnum.Fatal, message);
        }

        private void WriteToLog(LogMessageTypeEnum type, string message)
        {
            var fileName = GetFileName();
            using (var stream = File.Open(fileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
            using (var streamWriter = new StreamWriter(stream))
            {
                streamWriter.WriteLine($"{type} | {DateTime.Now.ToString(ConfigReader.DateFormatForLog)} | {message.Replace(System.Environment.NewLine, "\t")}");
            }
        }

        private string GetFileName()
        {
            if (!Directory.Exists(_logPath))
                Directory.CreateDirectory(_logPath);

            return Path.Combine(_logPath, DateTime.Now.ToString(_logNameFormat));
        }
    }
}