namespace Cart.Application.Domain.Core
{
    public class EventWrapper
    {
        public EventWrapper(Event @event, int version, string streamName)
        {
            StreamName = streamName;
            Id = @event.Id;
            Version = version;
            Event = @event;
        }
        public string StreamName { get; set; }
        public string Id { get; set; }
        public int Version { get; set; }
        public Event Event { get; set; }
    }
}
