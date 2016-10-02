namespace _01.ReformatCode
{
    using System;
    using System.Text;

    public class Event : IComparable
    {
        private readonly string location;

        private readonly string title;

        private DateTime date;

        public Event(DateTime date, string title, string location)
        {
            this.date = date;
            this.title = title;
            this.location = location;
        }

        public int CompareTo(object obj)
        {
            Event other = obj as Event;
            int byDate = this.date.CompareTo(other.date);
            int byTitle = string.Compare(this.title, other.title, StringComparison.Ordinal);
            int byLocation = string.Compare(this.location, other.location, StringComparison.Ordinal);

            if (byDate == 0)
            {
                if (byTitle == 0)
                {
                    return byLocation;
                }

                return byTitle;
            }

            return byDate;
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();
            toString.Append(this.date.ToString("yyyy-MM-ddTHH:mm:ss"));
            toString.Append(" | " + this.title);

            if (!string.IsNullOrEmpty(this.location))
            {
                toString.Append(" | " + this.location);
            }

            return toString.ToString();
        }
    }
}