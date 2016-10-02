namespace Logger.Reports
{
    public class WarningReport : Report
    {
        public override int ReportLevel => ReportLevelValues.WarnLevelValue;

        public override string ToString() => "Warning";
    }
}