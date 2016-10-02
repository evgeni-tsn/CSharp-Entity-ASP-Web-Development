namespace Logger.Models.Appenders
{
    using System;

    using Logger.Interfaces;

    public abstract class Appender : IAppender
    {
        private ILayout layout;

        protected Appender(ILayout layout)
        {
            this.layout = layout;
        }

        protected ILayout Layout
        {
            get
            {
                return this.layout;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Layout cannot be null");
                }
                this.layout = value;
            }
        }

        public abstract void Append(IMessage message);
    }
}