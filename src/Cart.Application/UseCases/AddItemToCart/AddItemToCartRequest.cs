namespace Cart.Application.UseCases.AddItemToCart
{
    public class AddItemToCartRequest
    {
        public string CartId { get; set; }
        public string SkuId { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
    }
}
