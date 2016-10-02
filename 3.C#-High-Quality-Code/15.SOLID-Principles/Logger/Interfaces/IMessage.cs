namespace Logger.Interfaces
{
    using System;

    public interface IMessage
    {
        DateTime Date { get; }

        IReport ReportLevel { get; }

        string MessageText { get; }
    }
}