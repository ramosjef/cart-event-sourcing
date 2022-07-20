using Cart.Application.Domain.Core;

namespace Cart.Application.Domain.CartAggregate.Events
{
    public class CartItemAdded : Event
    {
        public CartItemAdded(string id, string cartItemId, string skuId, int quantity, string name)
            : base(id)
        {
            CartItemId = cartItemId;
            SkuId = skuId;
            Quantity = quantity;
            Name = name;
        }
        public string CartItemId { get; private set; }
        public string SkuId { get; private set; }
        public int Quantity { get; private set; }
        public string Name { get; private set; }
    }
}