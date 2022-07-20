namespace Cart.Application.Domain.CartAggregate
{
    public class CartItem
    {
        public string Id { get; private set; }
        public string SkuId { get; private set; }
        public int Quantity { get; private set; }
        public string Name { get; private set; }

        public CartItem()
        {
        }

        public CartItem(string id, string skuId, int quantity, string name)
        {
            Id = id;
            SkuId = skuId;
            Quantity = quantity;
            Name = name;
        }
    }
}