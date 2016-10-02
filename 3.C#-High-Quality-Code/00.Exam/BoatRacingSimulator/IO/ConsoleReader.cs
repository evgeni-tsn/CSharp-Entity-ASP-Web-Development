namespace BoatRacingSimulator.IO
{
    using System;

    using Interfaces;

    public class ConsoleReader : IInputReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}