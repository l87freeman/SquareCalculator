using System;
using System.Collections.Generic;
using Services.Models;

namespace Services.Interfaces
{
    public interface ILogReader
    {
        ICollection<MessageDto> ReadLog(string logName);
        ICollection<LogDescriptionDto> LogList();
    }
}
