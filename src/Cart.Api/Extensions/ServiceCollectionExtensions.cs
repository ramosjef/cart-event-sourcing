using Cart.Application.UseCases.AddItemToCart;
using Cart.Application.UseCases.CreateCart;
using Cart.Application.UseCases.GetCart;
using Cart.Application.UseCases.RemoveCartItem;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Cart.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<IAddItemToCartPresenter<IActionResult>, Cart.Api.UseCases.AddItemToCart.Presenter>();
            services.AddScoped<ICreateCartPresenter<IActionResult>, Cart.Api.UseCases.CreateCart.Presenter>();
            services.AddScoped<IGetCartPresenter<IActionResult>, Cart.Api.UseCases.GetCart.Presenter>();
            services.AddScoped<IRemoveCartItemPresenter<IActionResult>, Cart.Api.UseCases.RemoveCartItem.Presenter>();

            return services;
        }
    }
}
