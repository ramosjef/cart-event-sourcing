using System.Linq;
using System.Threading.Tasks;

using Cart.Application.Domain.CartAggregate;
using Cart.Application.Domain.Core;

namespace Cart.Application.Infrastructure.Repositories
{
    internal class CartRepository : ICartRepository
    {
        private readonly IEventStore _eventStore;

        public CartRepository(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }
        public Task<Domain.CartAggregate.Cart> Get(string id)
        {
            Domain.CartAggregate.Cart result = default;

            var eventWrappers = _eventStore.GetEvents(id);

            if (eventWrappers.Any())
                result = new Domain.CartAggregate.Cart(id, eventWrappers.Select(e => e.Event));

            return Task.FromResult(result);
        }

        public Task Save(Domain.CartAggregate.Cart cart)
        {
            _eventStore.PersistEvents(cart.Changes);
            return Task.CompletedTask;
        }
    }
}
