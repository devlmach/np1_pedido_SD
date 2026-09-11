using trabalho_np1_pedido.Application.Dto;
using trabalho_np1_pedido.Application.Service.Interface;
using trabalho_np1_pedido.Data.Repository.Interface;
using trabalho_np1_pedido.Domain.Errors;

namespace trabalho_np1_pedido.Application.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task CreateOrderAsync(OrderItemAddDto orderItemAddDto)
        {
            await _orderRepository.CreateOrderAsync(orderItemAddDto);
        }

        public async Task DeleteOrderAsync(long id)
        {
            var _ = await _orderRepository.GetOrderByIdAsync(id)
                ?? throw new NotFoundException("Order not found");

            await _orderRepository.DeleteOrderAsync(id);
        }

        public async Task<List<OrderItemDto>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllOrdersAsync();

            if (orders == null || orders.Count == 0)
                return [];

            return orders;
        }

        public async Task<OrderItemDto> GetOrderByIdAsync(long id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id)
                ?? throw new NotFoundException("Order not found");

            return order;
        }

        public async Task UpdateOrderAsync(long id, OrderItemUpdateDto orderItemUpdateDto)
        {
            var _ = await _orderRepository.GetOrderByIdAsync(id)
                ?? throw new NotFoundException("Order not found");

            await _orderRepository.UpdateOrderAsync(id, orderItemUpdateDto);
        }
    }
}
