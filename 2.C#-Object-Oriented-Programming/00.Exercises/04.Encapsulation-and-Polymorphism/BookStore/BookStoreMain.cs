using BookStore.Interfaces;
using BookStore.UI;

namespace BookStore
{
    using Engine;

    public class BookStoreMain
    {
        public static void Main()
        {
            IRenderer render = new ConsoleRenderer();
            IInputHandler input = new ConsoleInputHandler();

            BookStoreEngine engine = new BookStoreEngine(render,input);
            engine.Run();
        }
    }
}
