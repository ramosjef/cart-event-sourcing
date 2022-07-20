using System.Threading.Tasks;
using Cart.Application.Domain.CartAggregate;

namespace Cart.Application.UseCases.CreateCart
{
    internal class CreateCartUseCase<TResult> : ICreateCartUseCase<TResult>
    {
        private readonly ICartRepository _cartRepository;
        private ICreateCartPresenter<TResult> _presenter;

        public CreateCartUseCase(ICartRepository cartRepository,
                                 ICreateCartPresenter<TResult> presenter)
        {
            _cartRepository = cartRepository;
            _presenter = presenter;
        }

        public async Task ExecuteAsync()
        {
            var cart = new Domain.CartAggregate.Cart();

            await _cartRepository.Save(cart);

            _presenter.Created(cart.Id);
        }
    }
}
