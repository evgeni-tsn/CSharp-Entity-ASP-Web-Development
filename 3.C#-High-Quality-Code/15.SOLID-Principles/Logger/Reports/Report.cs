namespace Logger.Reports
{
    using Logger.Interfaces;

    public abstract class Report : IReport
    {
        public abstract int ReportLevel { get; }
    }
}