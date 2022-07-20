using System.Net;
using Cart.Application.Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Cart.Application.UseCases.RemoveCartItem;

namespace Cart.Api.Controllers.RemoveCartItem
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "cart-v1")]
    [ProducesResponseType(typeof(MessageError), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(MessageError), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    [Route("api/v1/[controller]")]
    public sealed class CartController : ControllerBase
    {
        private readonly IRemoveCartItemUseCase<IActionResult> _removeCartItemUseCase;
        private readonly IRemoveCartItemPresenter<IActionResult> _presenter;

        public CartController(IRemoveCartItemUseCase<IActionResult> removeCartItemUseCase,
                              IRemoveCartItemPresenter<IActionResult> presenter)
        {
            _removeCartItemUseCase = removeCartItemUseCase;
            _presenter = presenter;
        }

        /// <summary>
        /// Remove um item do carrinho
        /// </summary>
        /// <param name="id">O id do carrinho</param>
        /// <param name="itemId">O id do item</param>
        /// <returns>ViewModel</returns>
        [HttpDelete("{id}/item/{itemId}")]
        public async Task<IActionResult> Get(
            [FromRoute] string id,
            [FromRoute] string itemId)
        {
            await _removeCartItemUseCase.ExecuteAsync(id, itemId);
            return _presenter.GetResult();
        }
    }
}
