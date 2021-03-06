namespace Server.Models
{
    using System;
    using System.Collections.Generic;

    public class EventCollection
    {
        private List<Event> events;

        public EventCollection(IEnumerable<Event> events)
        {
            this.events = new List<Event>(events);
        }

        public bool Empty
        {
            get
            {
                return this.events.Count == 0;
            }
        }

        public int Count
        {
            get
            {
                return this.events.Count;
            }
        }

        public Event this[int index]
        {
            get
            {
                return this.events[index];
            }
        }
    }
}