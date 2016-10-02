namespace Logger.Reports
{
    public class InfoReport : Report
    {
        public override int ReportLevel => ReportLevelValues.InfoLevelValue;

        public override string ToString() => "Info";
    }
}