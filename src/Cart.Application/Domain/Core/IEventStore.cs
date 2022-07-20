using System.Collections.Generic;

namespace Cart.Application.Domain.Core
{
    public interface IEventStore
    {
        IEnumerable<EventWrapper> GetEvents(string id);
        void PersistEvents(IEnumerable<EventWrapper> domainEvents);
    }
}
