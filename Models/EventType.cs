using System.ComponentModel;

namespace Server.Models
{
    public enum EventType
    {
        [Description()]
        Devotional,

        [Description()]
        Action,

        [Description()]
        ExternalEvent,

        [Description()]
        Other,
    }
}