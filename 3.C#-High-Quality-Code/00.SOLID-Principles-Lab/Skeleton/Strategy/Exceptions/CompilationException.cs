namespace Strategy.Exceptions
{
    using System;

    public class CompilationException : ApplicationException
    {
        public CompilationException(string msg)
            : base(msg)
        {
        }
    }
}
