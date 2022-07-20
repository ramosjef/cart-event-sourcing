using System;
using System.Threading.Tasks;

namespace Cart.Application.Domain.CartAggregate
{
    public interface ICartRepository
    {
        Task<Cart> Get(string id);
        Task Save(Cart cart);
    }
}
