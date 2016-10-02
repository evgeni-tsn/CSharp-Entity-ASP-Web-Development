namespace Logger
{
    using Logger.Core;
    using Logger.Interfaces;
    using Logger.Models.Appenders;
    using Logger.Models.Layouts;
    using Logger.Reports;

    public class Run
    {
        public static void Main()
        {
            ILayout simpleLayout = new SimpleLayout();
            IAppender consoleAppender = new ConsoleAppender(simpleLayout);
            ILogger logger = new Logger(consoleAppender);

            logger.WriteReport("Error parsing JSON.", new InfoReport());
            logger.WriteReport("User Pesho successfully registered.", new FatalReport());
            logger.WriteReport("Random error", new WarningReport());
        }
    }
}
