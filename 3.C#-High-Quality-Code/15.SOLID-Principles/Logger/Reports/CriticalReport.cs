namespace Logger.Reports
{
    public class CriticalReport : Report
    {
        public override int ReportLevel => ReportLevelValues.CriticalLevelValue;

        public override string ToString() => "Critical";
    }
}