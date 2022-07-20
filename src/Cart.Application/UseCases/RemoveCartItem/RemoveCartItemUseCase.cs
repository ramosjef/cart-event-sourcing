using System.Threading.Tasks;
using Cart.Application.Core;
using Cart.Application.Domain.CartAggregate;

namespace Cart.Application.UseCases.RemoveCartItem
{
    public class RemoveCartItemUseCase<TResult> : IRemoveCartItemUseCase<TResult>
    {
        private readonly ICartRepository _cartRepository;
        private IRemoveCartItemPresenter<TResult> _presenter;

        public RemoveCartItemUseCase(ICartRepository cartRepository,
                                     IRemoveCartItemPresenter<TResult> presenter)
        {
            _cartRepository = cartRepository;
            _presenter = presenter;
        }

        public async Task ExecuteAsync(string id, string itemId)
        {
            var cart = await _cartRepository.Get(id);

            if (cart != null)
            {
                var ok = cart.RemoveItem(itemId);

                if (ok)
                {
                    await _cartRepository.Save(cart);
                    _presenter.Success(ok);

                    return;
                }

                _presenter.NotFound(new MessageError("404", $"O item {itemId} não existe", string.Empty));
                return;
            }

            _presenter.NotFound(new MessageError("404", $"O carrinho {id} não existe", string.Empty));
        }
    }
}
