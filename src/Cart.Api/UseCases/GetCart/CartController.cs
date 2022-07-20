using System.Net;
using Cart.Application.Core;
using Cart.Application.UseCases.GetCart;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Cart.Application.DTO;

namespace Cart.Api.Controllers.GetCart
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "cart-v1")]
    [ProducesResponseType(typeof(MessageError), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(MessageError), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(CartDTO), (int)HttpStatusCode.OK)]
    [Route("api/v1/[controller]")]
    public sealed class CartController : ControllerBase
    {
        private readonly IGetCartUseCase<IActionResult> _getCartUseCase;
        private readonly IGetCartPresenter<IActionResult> _presenter;

        public CartController(IGetCartUseCase<IActionResult> getCartUseCase,
                              IGetCartPresenter<IActionResult> presenter)
        {
            _getCartUseCase = getCartUseCase;
            _presenter = presenter;
        }

        /// <summary>
        /// Obtém o carrinho
        /// </summary>
        /// <param name="id">O id do carrinho</param>
        /// <returns>ViewModel</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(
            [FromRoute] string id)
        {
            await _getCartUseCase.ExecuteAsync(id);
            return _presenter.GetResult();
        }
    }
}
