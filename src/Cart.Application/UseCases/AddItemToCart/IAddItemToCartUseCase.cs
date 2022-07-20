using System.Threading.Tasks;

namespace Cart.Application.UseCases.AddItemToCart
{
    public interface IAddItemToCartUseCase<TResult>
    {
        Task ExecuteAsync(AddItemToCartRequest request);
    }
}