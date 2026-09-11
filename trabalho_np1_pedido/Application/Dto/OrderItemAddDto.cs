using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using trabalho_np1_pedido.Common.Enum;

namespace trabalho_np1_pedido.Application.Dto
{
    public class OrderItemAddDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string ClientName { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public List<ProductItemDto> Products { get; set; }
        [JsonIgnore]
        public OrderStatus OrderStatus { get; set; }
    }
}
