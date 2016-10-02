namespace Logger.Models.Appenders
{
    using System;

    using Logger.Interfaces;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }

        public override void Append(IMessage message)
        {

//            if (message.ReportLevel >= this.ReportLevel)
//            {
                var formattedMsg = this.Layout.Format(message);

                Console.WriteLine(formattedMsg);
//            }
        }
    }
}