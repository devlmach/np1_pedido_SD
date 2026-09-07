using trabalho_np1_pedido.Application.Dto;

namespace trabalho_np1_pedido.Application.Service.Interface
{
    public interface IOrderService
    {
        Task<OrderItemDto> GetOrderByIdAsync(long id);
        Task<List<OrderItemDto>> GetAllOrdersAsync();
        Task CreateOrderAsync(OrderItemAddDto orderItemAddDto);
        Task UpdateOrderAsync(long id, OrderItemUpdateDto orderItemUpdateDto);
        Task DeleteOrderAsync(long id);
    }
}
