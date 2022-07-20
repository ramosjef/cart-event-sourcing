using Cart.Application.Core;

namespace Cart.Application.UseCases.RemoveCartItem
{
    public interface IRemoveCartItemPresenter<TResult> :
        INotFound<MessageError>,
        ISuccess<bool>,
        IGetResult<TResult>
    {
    }
}
