namespace OOP_Retake_Exam.IO
{
    using System;
    using Interfaces;

    public class ConsoleWriter : IOutputWriter
    {
        public void WriteLine(string line) => Console.WriteLine(line);

        public void Write(string text) => Console.Write(text);
    }
}