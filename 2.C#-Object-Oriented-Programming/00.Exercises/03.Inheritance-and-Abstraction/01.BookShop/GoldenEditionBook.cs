namespace _01.BookShop
{
    public class GoldenEditionBook : Book
    {
        public GoldenEditionBook(string title, string author, decimal price) 
            : base(title, author, price)
        {
        }

        public override decimal CurrPrice()
        {
            return this.Price*1.3m;
        }
    }
}