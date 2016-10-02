namespace Logger.Models.Layouts
{
    using Logger.Interfaces;

    public abstract class Layout : ILayout
    {
        public abstract string Format(IMessage msgToFormat);
    }
}