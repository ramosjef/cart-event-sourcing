using System;

namespace Cart.Application.Core
{
    public interface ISuccess<T>
    {
        void Success(T result);
    }
}
