using System.Net;
using System.Threading.Tasks;
using Cart.Application.UseCases.CreateCart;
using Cart.Application.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cart.Api.Controllers.CreateCart
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "cart-v1")]
    [ProducesResponseType(typeof(MessageError), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(MessageError), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.Created)]
    [Route("api/v1/[controller]")]
    public sealed class CartController : ControllerBase
    {
        private readonly ICreateCartUseCase<IActionResult> _createCartUseCase;
        private readonly ICreateCartPresenter<IActionResult> _presenter;

        public CartController(ILogger<CartController> logger,
                              ICreateCartUseCase<IActionResult> createCartUseCase,
                              ICreateCartPresenter<IActionResult> presenter)
        {
            _createCartUseCase = createCartUseCase;
            _presenter = presenter;
        }

        /// <summary>
        /// Cria um carrinho
        /// </summary>
        /// <returns>ViewModel</returns>
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            await _createCartUseCase.ExecuteAsync();
            return _presenter.GetResult();
        }
    }
}
