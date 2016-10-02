namespace OOP_Retake_Exam.Exceptions
{
    using System;

    public class InvalidVegetableException : Exception
    {
        public InvalidVegetableException(string message)
            : base(message)
        {
        }
    }
}