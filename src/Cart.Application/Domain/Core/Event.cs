namespace Cart.Application.Domain.Core
{
    public abstract class Event
    {
        public string Id { get; private set; }
        public Event(string id)
        {
            Id = id;
        }
    }
}
