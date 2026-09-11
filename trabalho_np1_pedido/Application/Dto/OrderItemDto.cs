using trabalho_np1_pedido.Common.Enum;

namespace trabalho_np1_pedido.Application.Dto
{
    public class OrderItemDto
    {
        public long OrderId { get; set; }
        public string ClientName { get; set; }
        public string Address { get; set; }
        public DateTime OrderDate { get; set; }
        public List<ProductItemDto> Products { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal TotalOrderPrice { get; set; }
    }
}
