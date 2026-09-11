using Microsoft.EntityFrameworkCore;
using trabalho_np1_pedido.Application.Dto;
using trabalho_np1_pedido.Common.Enum;
using trabalho_np1_pedido.Data.Context;
using trabalho_np1_pedido.Data.Repository.Interface;
using trabalho_np1_pedido.Domain.Entity;
using trabalho_np1_pedido.Domain.Errors;

namespace trabalho_np1_pedido.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<OrderItemDto> GetOrderByIdAsync(long id)
        {
            var order = await (from pedido in _context.Orders.AsNoTracking()
                               where pedido.Id == id && pedido.IsActive
                               select new OrderItemDto
                               {
                                   OrderId = pedido.Id,
                                   ClientName = pedido.ClientName,
                                   Address = pedido.Address,
                                   OrderDate = pedido.OrderDate,
                                   Products = pedido.Products,
                                   TotalOrderPrice = pedido.TotalOrderPrice,
                                   OrderStatus = pedido.OrderStatus
                               })
                               .FirstOrDefaultAsync();

            return order;
        }

        public async Task<List<OrderItemDto>> GetAllOrdersAsync()
        {
            var orders = await (from pedido in _context.Orders.AsNoTracking()
                                where pedido.IsActive
                               select new OrderItemDto
                               {
                                   OrderId = pedido.Id,
                                   ClientName = pedido.ClientName,
                                   Address = pedido.Address,
                                   OrderDate = pedido.OrderDate,
                                   Products = pedido.Products,
                                   TotalOrderPrice = pedido.TotalOrderPrice,
                                   OrderStatus = pedido.OrderStatus
                               })
                               .ToListAsync();

            if (orders is not null)
                orders = orders.OrderBy(s => s.OrderId).ToList();

            return orders;
        }

        public async Task CreateOrderAsync(OrderItemAddDto orderItemAddDto)
        {
            var addOrder = new Order
            {
                ClientName = orderItemAddDto.ClientName,
                Address = orderItemAddDto.Address,
                Products = orderItemAddDto.Products,
                OrderStatus = OrderStatus.Criado,
                TotalOrderPrice = orderItemAddDto.Products.Sum(p => p.TotalPrice),
            };

            await _context.Orders.AddAsync(addOrder);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderAsync(long id, OrderItemUpdateDto orderItemUpdateDto)
        {
            var response = await (from pedidos in _context.Orders
                                      where pedidos.Id == id && pedidos.IsActive
                                      select pedidos).FirstOrDefaultAsync()
                                      ?? throw new NotFoundException("Order not found");

            response.ClientName = orderItemUpdateDto.ClientName ?? response.ClientName;
            response.Address = orderItemUpdateDto.Address ?? response.Address;
            response.Products = orderItemUpdateDto.Products ?? response.Products;
            response.UpdatedAt = DateTime.UtcNow;
            response.TotalOrderPrice = orderItemUpdateDto.Products is not null ? orderItemUpdateDto.Products.Sum(s => s.TotalPrice) : response.TotalOrderPrice ;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(long id)
        {
            var response = await (from pedidos in _context.Orders
                                 where pedidos.Id == id && pedidos.IsActive
                                 select pedidos).FirstOrDefaultAsync();

            response!.IsActive = false;
            await _context.SaveChangesAsync();
        }
    }
}
