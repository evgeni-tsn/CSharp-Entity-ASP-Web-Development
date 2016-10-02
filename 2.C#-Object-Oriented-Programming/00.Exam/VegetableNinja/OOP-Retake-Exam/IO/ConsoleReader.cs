namespace OOP_Retake_Exam.IO
{
    using System;
    using Interfaces;

    public class ConsoleReader : IInputReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}