namespace BoatRacingSimulator.IO
{
    using System;

    using BoatRacingSimulator.Interfaces;

    public class ConsoleWriter : IOutputWriter
    {
        public void WriteLine(string message) => Console.WriteLine(message);
    }
}