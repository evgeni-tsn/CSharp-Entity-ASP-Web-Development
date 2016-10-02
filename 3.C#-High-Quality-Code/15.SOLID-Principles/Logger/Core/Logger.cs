namespace Logger.Core
{
    using System;
    using System.Collections.Generic;
   
    using Factories;

    using Interfaces;

    public class Logger : ILogger
    {
        private readonly IList<IAppender> appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = new List<IAppender>(appenders);
        }

        public IReport ReportLevel { get; set; }

        private void WriteLog(string messageText, IReport reportLevel)
        {
            var message = MessageFactory.Create(DateTime.Now, reportLevel, messageText);

            foreach (var appender in this.appenders)
            {
                appender.Append(message);
            }
        }

        public void WriteReport(string message, IReport reportLevel) => this.WriteLog(message,reportLevel);
    }
}