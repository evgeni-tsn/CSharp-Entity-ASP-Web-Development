namespace BookStore.Interfaces
{
    public interface IBook
    {
        string Title { get; }
        
        decimal Price { get; } 
    }
}