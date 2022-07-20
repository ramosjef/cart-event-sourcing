using Cart.Application.Core;

namespace Cart.Application.UseCases.CreateCart
{
    public interface ICreateCartPresenter<TResult> :
        ICreated<string>,
        IGetResult<TResult>
    {
    }
}
