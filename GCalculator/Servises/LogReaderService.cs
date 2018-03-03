using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using Services.Interfaces;
using Services.Models;
using Services.Extentions;

namespace Services
{
    public class FileLogReaderService:ILogReader
    {
        private readonly string _fileLogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            ConfigurationManager.AppSettings["fileLogPath"]);
        private readonly string _logNameFormat = ConfigurationManager.AppSettings["logNameFormat"];

        /// <summary>
        /// <exception cref="DirectoryNotFoundException"></exception>
        /// </summary>
        /// <returns></returns>
        public ICollection<MessageDto> ReadLog(string logName)
        {
            var list = Directory.GetFiles(_fileLogPath)
                .Select(x => new FileInfo(x))
                .Where(x => x.Name == logName)
                .SelectMany(ReadFile).ToMessages("|");
            return list;
        }

        /// <summary>
        /// <exception cref="DirectoryNotFoundException"></exception>
        /// </summary>
        /// <returns></returns>
        public ICollection<LogDescriptionDto> LogList()
        {
            var list = Directory.GetFiles(_fileLogPath);
            return list.Select(s => new FileInfo(s))
                .Select(fi => new LogDescriptionDto {Date = fi.CreationTime, Name = fi.Name}).ToList();
        }

        private IEnumerable<string> ReadFile(FileInfo fileInfo)
        {
            var list = new List<string>();
            using (var stream = fileInfo.OpenRead())
            using (var streamReader = new StreamReader(stream))
            {
                string str;
                while ((str = streamReader.ReadLine()) != null)
                {
                    list.Add(str);
                }
            }
            return list;
        }
    }
}
