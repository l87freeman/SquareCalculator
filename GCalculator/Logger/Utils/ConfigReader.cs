using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace Logger.Utils
{
    public static class ConfigReader
    {
        public static List<string> LoggerTypesNames
        {
            get
            {
                var logSection = ConfigurationManager.GetSection("loggersTypes") as LoggerConfigurationSection;
                var list = new List<string>();
                if (logSection != null)
                {
                    foreach (var tp in logSection.Instances)
                    {
                        list.Add((tp as ConfigInstanceElement)?.Type??"");
                    }
                }
                return list;
            }
        }
    
        public static string LogNameFormat => GetAppSetting("logNameFormat");

        public static string FileLogPath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            GetAppSetting("fileLogPath"));

        public static string DateFormatForLog => GetAppSetting("dateFormatForLog");

        private static string GetAppSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
