using Cart.Application.Core;

namespace Cart.Application.UseCases.AddItemToCart
{
    public interface IAddItemToCartPresenter<TResult> :
        ICreated<string>,
        INotFound<MessageError>,
        IGetResult<TResult>
    {
    }
}
