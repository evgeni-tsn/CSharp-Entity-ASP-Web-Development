namespace Logger.Factories
{
    using System;

    using Interfaces;
    using Models;

    public class MessageFactory
    {
        public static IMessage Create(DateTime date, IReport reportLevel, string messageText)
        {
            IMessage message = new Message(date, reportLevel, messageText);

            return message;
        }
    }
}