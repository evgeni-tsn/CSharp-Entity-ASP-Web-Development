using System;
using BookStore.Interfaces;

namespace BookStore.UI
{
    public class ConsoleInputHandler: IInputHandler
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}