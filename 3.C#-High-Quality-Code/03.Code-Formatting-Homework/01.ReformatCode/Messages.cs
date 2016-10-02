namespace _01.ReformatCode
{
    using System.Text;

    public static class Messages
    {
        public static readonly StringBuilder Output = new StringBuilder();

        public static void EventAdded()
        {
            Output.Append("Event added\n");
        }

        public static void EventDeleted(int x)
        {
            if (x == 0)
            {
                NoEventsFound();
            }
            else
            {
                Output.AppendFormat("{0} Events deleted\n", x);
            }
        }

        public static void NoEventsFound()
        {
            Output.Append("No Events found{0}");
        }

        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                Output.Append(eventToPrint + "\n");
            }
        }
    }
}