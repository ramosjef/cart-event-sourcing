using System.Threading.Tasks;

namespace Cart.Application.UseCases.CreateCart
{
    public interface ICreateCartUseCase<TResult>
    {
        Task ExecuteAsync();
    }
}