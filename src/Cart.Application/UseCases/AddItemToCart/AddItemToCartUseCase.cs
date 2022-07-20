using System.Threading.Tasks;
using Cart.Application.Domain.CartAggregate;
using Cart.Application.Core;

namespace Cart.Application.UseCases.AddItemToCart
{
    internal class AddItemToCartUseCase<TResult> : IAddItemToCartUseCase<TResult>
    {
        private readonly ICartRepository _cartRepository;
        private IAddItemToCartPresenter<TResult> _presenter;

        public AddItemToCartUseCase(ICartRepository cartRepository, 
                                    IAddItemToCartPresenter<TResult> presenter)
        {
            _cartRepository = cartRepository;
            _presenter = presenter;
        }

        public async Task ExecuteAsync(AddItemToCartRequest request)
        {
            var cart = await _cartRepository.Get(request.CartId);

            if (cart != null)
            {
                var cartItemId = cart.AddItem(request.SkuId, request.Quantity, request.Name);

                await _cartRepository.Save(cart);

                _presenter.Created(cartItemId);

                return;
            }

            var notFound = new MessageError("404", $"O carrinho {request.CartId} não existe", "");
            _presenter.NotFound(notFound);
        }
    }
}
