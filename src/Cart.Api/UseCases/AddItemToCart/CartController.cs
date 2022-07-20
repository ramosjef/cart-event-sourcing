using System.Net;
using Cart.Application.UseCases.AddItemToCart;
using Cart.Application.Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Cart.Api.Controllers.AddItemToCart
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "cart-v1")]
    [ProducesResponseType(typeof(MessageError), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(MessageError), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.Created)]
    [Route("api/v1/[controller]")]
    public sealed class CartController : ControllerBase
    {
        private readonly IAddItemToCartUseCase<IActionResult> _addItemToCartUseCase;
        private readonly IAddItemToCartPresenter<IActionResult> _presenter;

        public CartController(ILogger<CartController> logger,
                              IAddItemToCartUseCase<IActionResult> addItemToCartUseCase,
                              IAddItemToCartPresenter<IActionResult> presenter)
        {
            _addItemToCartUseCase = addItemToCartUseCase;
            _presenter = presenter;
        }

        /// <summary>
        /// Adiciona um item no carrinho
        /// </summary>
        /// <param name="cartId">O id do carrinho</param>
        /// <param name="request">Payload contendo o item e qtd.</param>
        /// <returns>ViewModel</returns>
        [HttpPost("{cartId}/item")]
        public async Task<IActionResult> PostItem(
            [FromRoute] string cartId,
            [FromBody] AddItemToCartRequest request)
        {
            request.CartId = cartId;

            await _addItemToCartUseCase.ExecuteAsync(request);

            return _presenter.GetResult();
        }
    }
}
