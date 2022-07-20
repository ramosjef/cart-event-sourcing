namespace Cart.Application.Core
{
    public interface ICreated<T>
    {
        void Created(T input);
    }
}
