namespace Logger.Interfaces
{
    public interface ILayout
    {
        string Format(IMessage msgToFormat);
    }
}