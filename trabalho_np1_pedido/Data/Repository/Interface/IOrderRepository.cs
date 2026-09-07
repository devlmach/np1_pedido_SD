using trabalho_np1_pedido.Application.Dto;

namespace trabalho_np1_pedido.Data.Repository.Interface
{
    public interface IOrderRepository
    {
        Task<OrderItemDto> GetOrderByIdAsync(long id);
        Task<List<OrderItemDto>> GetAllOrdersAsync();
        Task CreateOrderAsync(OrderItemAddDto orderItemAddDto);
        Task UpdateOrderAsync(long id, OrderItemUpdateDto orderItemUpdateDto);
        Task DeleteOrderAsync(long id);
    }
}
