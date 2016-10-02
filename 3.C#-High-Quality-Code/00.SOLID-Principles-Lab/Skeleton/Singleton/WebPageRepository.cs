namespace Singleton
{
    using System;
    using System.Collections.Generic;

    public class WebPageRepository
    {
        private readonly Queue<string> addresses;
        private static WebPageRepository createInstance;
        private static object syncRoot = new Object();

        private WebPageRepository()
        {
            this.addresses = new Queue<string>();
            this.Seed();
        }

        public static WebPageRepository CreateInstance
        {
            get
            {
                if (createInstance == null)
                {
                    lock (syncRoot)
                    {
                        if (createInstance == null)
                            createInstance = new WebPageRepository();
                    }
                }
                return createInstance;
            }
        }

        public bool IsEmpty => this.addresses.Count == 0;

        public void Add(string address) => this.addresses.Enqueue(address);

        public string Remove() => this.addresses.Dequeue();

        private void Seed()
        {
            this.addresses.Enqueue("https://www.google.bg/");
        }
    }
}
