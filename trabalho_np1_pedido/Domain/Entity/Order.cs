using System.Text.Json.Serialization;
using trabalho_np1_pedido.Application.Dto;
using trabalho_np1_pedido.Common.Enum;
using trabalho_np1_pedido.Domain.Entity.Base;

namespace trabalho_np1_pedido.Domain.Entity
{
    public class Order : EntityBase
    {
        public string ClientName { get; set; }
        public string Address { get; set; }
        [JsonIgnore]
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public List<ProductItemDto> Products { get; set; }
        public decimal TotalOrderPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
