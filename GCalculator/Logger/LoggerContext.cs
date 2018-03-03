using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Logger.Exceptions;
using Logger.Interfaces;
using Logger.Utils;

namespace Logger
{
    public class LoggerContext : ILogger
    {
        private static List<ILogger> _loggers;
        private static ILogger _instance;

        /// <summary>
        /// <exception cref="Logger.Exceptions.LoggerInitException">Details in inner exception property</exception>
        /// </summary>
        public static ILogger Instance
        {
            get
            {
                _instance = _instance ?? new LoggerContext();
                return _instance;
            }
        }

        private LoggerContext()
        {
            InitLoggers();
        }

        /// <summary>
        /// <exception cref="Logger.Exceptions.LoggerWriteException">Details in inner exception property</exception>
        /// </summary>
        public void Info(string message)
        {
            Parallel.ForEach(_loggers, l => l.Info(message));
        }

        /// <summary>
        /// <exception cref="Logger.Exceptions.LoggerWriteException">Details in inner exception property</exception>
        /// </summary>
        public void Warn(string message)
        {
            Parallel.ForEach(_loggers, l => l.Warn(message));
        }

        /// <summary>
        /// <exception cref="Logger.Exceptions.LoggerWriteException">Details in inner exception property</exception>
        /// </summary>
        public void Error(string message)
        {
            Parallel.ForEach(_loggers, l => l.Error(message));
        }

        /// <summary>
        /// <exception cref="Logger.Exceptions.LoggerWriteException">Details in inner exception property</exception>
        /// </summary>
        public void Debug(string message)
        {
            Parallel.ForEach(_loggers, l => l.Debug(message));
        }

        /// <summary>
        /// <exception cref="Logger.Exceptions.LoggerWriteException">Details in inner exception property</exception>
        /// </summary>
        public void Fatal(string message)
        {
            Parallel.ForEach(_loggers, l => l.Fatal(message));
        }

        private void InitLoggers()
        {
            try
            {
                _loggers = new LoggerPlugginReader().GetLoggersInstances<ILogger>(ConfigReader.LoggerTypesNames);
            }
            catch (ReflectionTypeLoadException ex)
            {
                throw new LoggerInitException("Cannot load an assembly", ex);
            }
            catch (ArgumentNullException ex)
            {
                throw new LoggerInitException("Cannot find a type in assembly", ex);
            }
            catch (Exception ex)
            {
                throw new LoggerInitException("Fail", ex);
            }
        }
    }
}
