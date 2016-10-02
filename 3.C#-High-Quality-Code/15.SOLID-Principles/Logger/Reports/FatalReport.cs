namespace Logger.Reports
{
    public class FatalReport : Report
    {
        public override int ReportLevel => ReportLevelValues.FatalLevelValue;

        public override string ToString() => "Fatal";
    }
}