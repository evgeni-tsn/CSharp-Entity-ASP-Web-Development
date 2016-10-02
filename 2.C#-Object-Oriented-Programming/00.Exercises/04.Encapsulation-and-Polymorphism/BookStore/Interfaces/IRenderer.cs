namespace BookStore.Interfaces
{
    public interface IRenderer
    {
        void WriteLine(string message, params string[] parameters);
    }
}