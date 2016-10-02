namespace _01.ReformatCode
{
    using System;
    using Wintellect.PowerCollections;

    public class EventHolder
    {
        public readonly MultiDictionary<string, Event> ByTitle = new MultiDictionary<string, Event>(true);

        private readonly OrderedBag<Event> byDate = new OrderedBag<Event>();

        public void AddEvent(DateTime date, string title, string location)
        {
            Event newEvent = new Event(date, title, location);
            this.ByTitle.Add(title.ToLower(), newEvent);
            this.byDate.Add(newEvent);
            Messages.EventAdded();
        }

        public void DeleteEvents(string titleToDelete)
        {
            string title = titleToDelete.ToLower();
            int removed = 0;
            foreach (var eventToRemove in this.ByTitle[title])
            {
                removed++;
                this.byDate.Remove(eventToRemove);
            }

            this.ByTitle.Remove(title);
            Messages.EventDeleted(removed);
        }

        public void ListEvents(DateTime date, int count)
        {
            OrderedBag<Event>.View eventsToShow = this.byDate.RangeFrom(
                new Event(date, string.Empty, string.Empty), 
                true);
            int showed = 0;
            foreach (var eventToShow in eventsToShow)
            {
                if (showed == count)
                {
                    break;
                }

                Messages.PrintEvent(eventToShow);

                showed++;
            }

            if (showed == 0)
            {
                Messages.NoEventsFound();
            }
        }
    }
}