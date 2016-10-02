namespace Logger.Interfaces
{
    public interface IAppender
    {
        void Append(IMessage message);
    }
}