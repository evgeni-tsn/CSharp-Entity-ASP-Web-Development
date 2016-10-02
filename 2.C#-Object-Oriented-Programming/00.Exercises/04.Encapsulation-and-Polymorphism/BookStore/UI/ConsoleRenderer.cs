using System;
using BookStore.Interfaces;

namespace BookStore.UI
{
    public class ConsoleRenderer:IRenderer
    {
        public void WriteLine(string message, params string[] parameters)
        {
            Console.WriteLine(message, parameters);
        }
    }
}