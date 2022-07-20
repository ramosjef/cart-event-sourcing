using System.Threading.Tasks;

namespace Cart.Application.UseCases.RemoveCartItem
{
    public interface IRemoveCartItemUseCase<TResult>
    {
        Task ExecuteAsync(string id, string itemId);
    }
}
