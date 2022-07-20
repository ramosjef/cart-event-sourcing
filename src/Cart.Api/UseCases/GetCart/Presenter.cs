using System;
using System.Net;
using Cart.Application.Core;
using Cart.Application.DTO;
using Cart.Application.UseCases.GetCart;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cart.Api.UseCases.GetCart
{
    public class Presenter : IGetCartPresenter<IActionResult>
    {
        private readonly IHttpContextAccessor _context;
        private IActionResult _view;
        public Presenter(IHttpContextAccessor context) => _context = context;
        public void NotFound(MessageError input) => _view = new ObjectResult(input) { StatusCode = (int)HttpStatusCode.NotFound };
        public void Success(CartDTO result) => _view = new ObjectResult(result) { StatusCode = (int)HttpStatusCode.OK };
        public IActionResult GetResult() => _view;
    }
}
