namespace Logger.Reports
{
    public class ErrorReport : Report
    {
        public override int ReportLevel => ReportLevelValues.ErrorLevelValue;

        public override string ToString() => "Error";
    }
}