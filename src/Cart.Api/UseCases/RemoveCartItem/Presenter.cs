using System.Net;
using Cart.Application.Core;
using Cart.Application.UseCases.RemoveCartItem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cart.Api.UseCases.RemoveCartItem
{
    public class Presenter : IRemoveCartItemPresenter<IActionResult>
    {
        private readonly IHttpContextAccessor _context;
        private IActionResult _view;
        public Presenter(IHttpContextAccessor context) => _context = context;
        public void NotFound(MessageError input) => _view = new ObjectResult(input) { StatusCode = (int)HttpStatusCode.NotFound };
        public void Success(bool result) => _view = new ObjectResult(result) { StatusCode = (int)HttpStatusCode.NotFound };
        public IActionResult GetResult() => _view;
    }
}
