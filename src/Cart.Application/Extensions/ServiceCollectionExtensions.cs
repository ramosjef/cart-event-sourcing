using Cart.Application.Domain.CartAggregate;
using Cart.Application.Domain.Core;
using Cart.Application.Infrastructure.Repositories;
using Cart.Application.Infrastructure.Repositories.InMemory.Store;
using Cart.Application.UseCases.AddItemToCart;
using Cart.Application.UseCases.CreateCart;
using Cart.Application.UseCases.GetCart;
using Cart.Application.UseCases.RemoveCartItem;

using Microsoft.Extensions.DependencyInjection;

namespace Cart.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped(typeof(ICreateCartUseCase<>), typeof(CreateCartUseCase<>));
            services.AddScoped(typeof(IAddItemToCartUseCase<>), typeof(AddItemToCartUseCase<>));
            services.AddScoped(typeof(IGetCartUseCase<>), typeof(GetCartUseCase<>));
            services.AddScoped(typeof(IRemoveCartItemUseCase<>), typeof(RemoveCartItemUseCase<>));

            services.AddSingleton<IEventStore, EventStore>();
            services.AddScoped<ICartRepository, CartRepository>();

            return services;
        }
    }
}
