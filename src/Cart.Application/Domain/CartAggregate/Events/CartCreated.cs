using Cart.Application.Domain.Core;

namespace Cart.Application.Domain.CartAggregate.Events
{
    public class CartCreated : Event
    {
        public CartCreated(string id)
            : base(id)
        {

        }
    }
}
