using System;

namespace Services.Models
{
    public class MessageDto
    {
        public string Type { get; set; }
        public DateTime? Date { get; set; }
        public string Message { get; set; }
    }
}
