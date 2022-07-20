using System.Threading.Tasks;
using Cart.Application.Domain.CartAggregate;
using Cart.Application.Core;
using Cart.Application.DTO;
using System.Text.Json;

namespace Cart.Application.UseCases.GetCart
{
    public class GetCartUseCase<TResult> : IGetCartUseCase<TResult>
    {
        private readonly ICartRepository _cartRepository;
        private IGetCartPresenter<TResult> _presenter;
        public GetCartUseCase(ICartRepository cartRepository,
                              IGetCartPresenter<TResult> presenter)
        {
            _cartRepository = cartRepository;
            _presenter = presenter;
        }
        public async Task ExecuteAsync(string id)
        {
            var cart = await _cartRepository.Get(id);

            if (cart != null)
            {
                var json = JsonSerializer.Serialize(cart);
                var response = JsonSerializer.Deserialize<CartDTO>(json);

                _presenter.Success(response);

                return;
            }

            var notFound = new MessageError("404", $"O carrinho {id} não existe", "");
            _presenter.NotFound(notFound);
        }
    }
}
