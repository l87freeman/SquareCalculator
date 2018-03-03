using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using Services.Models;

namespace Services.Extentions
{
    public static class IEnumerableMessageExtentions
    {
        private static readonly string DateFormatForLog = ConfigurationManager.AppSettings["dateFormatForLog"];

        public static List<MessageDto> ToMessages(this IEnumerable<string> messageStrs, string divader)
        {
            var mapped = messageStrs.AsParallel().Select(x =>
            {
                var messageInarray = x.Split(new string[] {divader}, StringSplitOptions.None);
                return new MessageDto
                {
                    Type = messageInarray[0].Trim(),
                    Date = ParseDt(messageInarray[1].Trim()),
                    Message = messageInarray[2].Trim()
                };
            }).ToList();
            return mapped;
        }

        private static DateTime ParseDt(string dateStr)
        {
            DateTime dt;
            try
            {
                dt = DateTime.ParseExact(dateStr, DateFormatForLog, CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                dt = DateTime.MinValue;
            }
            return dt;
        }
    }
}
