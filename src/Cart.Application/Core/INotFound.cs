using System;

namespace Cart.Application.Core
{
    public interface INotFound<T>
    {
        void NotFound(T input);
    }
}
