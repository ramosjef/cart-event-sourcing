using System.Collections.Generic;
using System.Linq;
using Cart.Application.Domain.Core;

namespace Cart.Application.Infrastructure.Repositories.InMemory.Store
{
    internal class EventStore : IEventStore
    {
        private List<EventWrapper> _events = new List<EventWrapper>();

        public IEnumerable<EventWrapper> GetEvents(string streamName)
        {
            return _events.Where(e => e.Id == streamName);
        }

        public void PersistEvents(IEnumerable<EventWrapper> domainEvents)
        {
            _events.AddRange(domainEvents);
        }
    }
}
