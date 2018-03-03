using System;
using System.Runtime.Serialization;

namespace Logger.Exceptions
{
    public class LoggerWriteException : Exception
    {
        public LoggerWriteException()
        {
        }

        public LoggerWriteException(string message) : base(message)
        {
        }

        public LoggerWriteException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected LoggerWriteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
