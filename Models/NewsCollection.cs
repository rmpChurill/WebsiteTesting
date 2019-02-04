namespace Server.Models
{
    using System;
    using System.Collections.Generic;

    public class NewsCollection
    {
        private List<News> news;

        public NewsCollection(IEnumerable<News> news)
        {
            this.news = new List<News>(news);
        }

        public bool Empty
        {
            get
            {
                return this.news.Count == 0;
            }
        }

        public int Count
        {
            get
            {
                return this.news.Count;
            }
        }

        public News this[int index]
        {
            get
            {
                return this.news[index];
            }
        }
    }
}