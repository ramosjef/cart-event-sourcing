namespace Cart.Application.Core
{
    public interface IGetResult<TRes>
    {
        TRes GetResult();
    }
}
