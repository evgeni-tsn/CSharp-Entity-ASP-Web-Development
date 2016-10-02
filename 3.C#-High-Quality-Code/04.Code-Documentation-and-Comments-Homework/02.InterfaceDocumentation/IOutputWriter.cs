namespace Empires.Contracts
{
    /// <summary>
    /// Higher abstraction for writer
    /// </summary>
    public interface IOutputWriter
    {
        void Print(string message);
    }
}
