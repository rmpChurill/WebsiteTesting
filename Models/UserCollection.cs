namespace Server.Models
{
    using System;
    using System.Collections.Generic;

    public class UserCollection
    {
        private List<User> users;

        public UserCollection(IEnumerable<User> user)
        {
            this.users = new List<User>(user);
        }

        public bool Empty
        {
            get
            {
                return this.users.Count == 0;
            }
        }

        public int Count
        {
            get
            {
                return this.users.Count;
            }
        }

        public User this[int index]
        {
            get
            {
                return this.users[index];
            }
        }
    }
}