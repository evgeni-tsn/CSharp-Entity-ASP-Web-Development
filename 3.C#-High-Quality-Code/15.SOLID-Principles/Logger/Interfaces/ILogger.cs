namespace Logger.Interfaces
{
    public interface ILogger
    {
        void WriteReport(string message, IReport reportLevel);
    }
}