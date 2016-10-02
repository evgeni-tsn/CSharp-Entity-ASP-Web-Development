namespace Logger.Models
{
    using System;

    using Logger.Interfaces;

    public class Message : IMessage
    {
        private string messageText;

        public Message(DateTime date, IReport reportLevel, string messageText)
        {
            this.Date = date;
            this.ReportLevel = reportLevel;
            this.MessageText = messageText;
        }

        public DateTime Date { get; }

        public IReport ReportLevel { get; }

        public string MessageText
        {
            get
            {
                return this.messageText;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value), "Message Text cannot be null or empty.");
                }

                this.messageText = value;
            }
        }
    }
}