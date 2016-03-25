﻿namespace Revolution.Logging
{
    public enum LogEntryColor
    {
        Default,
        Grey,
        DarkGrey,
        Green,
        Red,
        Yellow
    }

    public class LogEntry
    {
        public string Message { get; set; }
        public LogEntryColor Color { get; set; } = LogEntryColor.Default;
    }
}