using System.Net;
using Cart.Application.UseCases.CreateCart;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cart.Api.UseCases.CreateCart
{
    public class Presenter : ICreateCartPresenter<IActionResult>
    {
        private readonly IHttpContextAccessor _context;
        private IActionResult _view;
        public Presenter(IHttpContextAccessor context) => _context = context;
        public void Created(string input) => _view = new ObjectResult(input) { StatusCode = (int)HttpStatusCode.Created };
        public IActionResult GetResult() => _view;
    }
}
