using Microsoft.AspNetCore.Mvc;
using trabalho_np1_pedido.Application.Dto;
using trabalho_np1_pedido.Application.Service.Interface;
using trabalho_np1_pedido.Common.Middleware;

namespace trabalho_np1_pedido.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Endpoint responsável por retornar um pedido pelo ID.
        /// </summary>
        [HttpGet("{id:long}")]
        [ProducesResponseType(typeof(OrderItemDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderItemDto>> GetOrderById([FromRoute] long id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            return Ok(order);
        }

        /// <summary>
        /// Endpoint responsável por retornar uma lista de pedidos.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(List<OrderItemDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<OrderItemDto>>> GetAllOrdersAsync()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        /// <summary>
        /// Endpoint responsável por criar um novo pedido.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateOrderAsync([FromBody] OrderItemAddDto orderItemAddDto)
        {
            await _orderService.CreateOrderAsync(orderItemAddDto);
            return Created();
        }

        /// <summary>
        /// Endpoint responsável por atualizar um pedido existente pelo ID.
        /// </summary>
        [HttpPatch("{id:long}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateOrderAsync([FromRoute] long id, [FromBody] OrderItemUpdateDto orderItemUpdateDto)
        {
            await _orderService.UpdateOrderAsync(id, orderItemUpdateDto);
            return NoContent();
        }

        /// <summary>
        /// Endpoint responsável por alterar apenas o status de um pedido existente pelo ID.
        /// </summary>
        [HttpPatch("{id:long}/status")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateOrderStatusAsync([FromRoute] long id, [FromBody] OrderStatusUpdateDto orderStatusUpdateDto)
        {
            await _orderService.UpdateOrderStatusAsync(id, orderStatusUpdateDto);
            return NoContent();
        }

        /// <summary>
        /// Endpoint responsável por deletar um pedido pelo ID.
        /// </summary>
        [HttpDelete("{id:long}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteOrderAsync([FromRoute] long id)
        {
            await _orderService.DeleteOrderAsync(id);
            return NoContent();
        }
    }
}