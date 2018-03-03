using System;
using System.Runtime.Serialization;

namespace Logger.Exceptions
{
    public class LoggerInitException : Exception
    {
        public LoggerInitException()
        {
        }

        public LoggerInitException(string message) : base(message)
        {
        }

        public LoggerInitException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected LoggerInitException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
