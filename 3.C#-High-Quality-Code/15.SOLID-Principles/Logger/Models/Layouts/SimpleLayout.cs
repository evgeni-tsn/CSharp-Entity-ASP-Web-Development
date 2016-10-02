namespace Logger.Models.Layouts
{
    using Logger.Interfaces;

    public class SimpleLayout : Layout
    {
        public override string Format(IMessage msgToFormat)
        {
            var formattedMessage = $"{msgToFormat.Date} - {msgToFormat.ReportLevel} - {msgToFormat.MessageText}";

            return formattedMessage;
        }
    }
}