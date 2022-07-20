using Cart.Application.Core;
using Cart.Application.DTO;

namespace Cart.Application.UseCases.GetCart
{
    public interface IGetCartPresenter<TResult> :
        ISuccess<CartDTO>,
        INotFound<MessageError>,
        IGetResult<TResult>
    {
    }
}
