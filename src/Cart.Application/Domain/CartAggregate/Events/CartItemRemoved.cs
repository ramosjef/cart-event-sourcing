using Cart.Application.Domain.Core;

namespace Cart.Application.Domain.CartAggregate.Events
{
    public class CartItemRemoved : Event
    {
        public CartItemRemoved(string id, string itemId) : base(id) => ItemId = itemId;
        public string ItemId { get; set; }
    }
}