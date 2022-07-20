using System.Net;
using Cart.Application.Core;
using Cart.Application.UseCases.AddItemToCart;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cart.Api.UseCases.AddItemToCart
{
    public class Presenter : IAddItemToCartPresenter<IActionResult>
    {
        private readonly IHttpContextAccessor _context;
        private IActionResult _view;
        public Presenter(IHttpContextAccessor context) => _context = context;
        public void Created(string input) => _view = new ObjectResult(input) { StatusCode = (int)HttpStatusCode.Created };
        public void NotFound(MessageError input) => _view = new ObjectResult(input) { StatusCode = (int)HttpStatusCode.NotFound };
        public IActionResult GetResult() => _view;
    }
}
