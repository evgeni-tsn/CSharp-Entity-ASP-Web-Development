using System;
using System.Threading;

namespace _03.AsynchronousTimer
{
    public class AsyncTimer
    {
        private int ticks;
        private int t;

        public AsyncTimer(Action<int> method, int ticks, int t)
        {
            this.MethodToExecute = method;
            this.Ticks = ticks;
            this.T = t;
        }

        public Action<int> MethodToExecute { get; private set; }

        public int Ticks
        {
            get { return this.ticks; }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("ticks", "The method should be executed at least once.");
                }

                this.ticks = value;
            }
        }

        public int T
        {
            get { return this.t; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("t", "The sleep time cannot be negative.");
                }

                this.t = value;
            }
        }

        // makes sure the Asynchronous Timer will be working on the background
        public void ExecuteAction()
        {
            Thread parallelThread = new Thread(this.Run);
            parallelThread.Start();
        }

        private void Run()
        {
            // counts "Ticks"
            for (int i = 0; i < this.Ticks; i++)
            {
                Thread.Sleep(this.T); // adds a "T" milliseconds interval between ticks
                Random random = new Random();

                if (this.MethodToExecute != null)
                {
                    this.MethodToExecute(random.Next(33, 127));
                    // adds a random number as argument, each time the method is executed
                }
            }
        }
    }
}