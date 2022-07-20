using System.Threading.Tasks;

namespace Cart.Application.UseCases.GetCart
{
    public interface IGetCartUseCase<TResult>
    {
        Task ExecuteAsync(string id);
    }
}
