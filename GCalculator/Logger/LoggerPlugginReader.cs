using System;
using System.Collections.Generic;
using System.Linq;

namespace Logger
{
    internal class LoggerPlugginReader
    {
        public List<T> GetLoggersInstances<T>(List<string> logrsTypesNames)
        {
            var tps = GetType().Assembly.GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(T)) && logrsTypesNames.Contains(t.FullName))
                .Select(t => (T) Activator.CreateInstance(t)).ToList();
            return tps;
        }
    }
}
