namespace Logger.Models.Appenders
{
    using System;
    using System.IO;

    using Logger.Interfaces;

    public class FileAppender : Appender
    {
        private string filePath;

        public FileAppender(ILayout layout)
            : base(layout)
        {
        }

        public string FilePath
        {
            get
            {
                return this.filePath;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value), "filePath path cannot be null or empty.");
                }

                this.filePath = value;
            }
        }

        public override void Append(IMessage message)
        {
//            if (message.ReportLevel >= this.LogLevel)
//            {
                using (var writer = new StreamWriter(this.FilePath, true))
                {
                    var formattedMessage = this.Layout.Format(message);

                    writer.WriteLine(formattedMessage);
                }
//            }
        }
    }
}