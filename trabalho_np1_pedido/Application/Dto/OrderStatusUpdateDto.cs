using System.ComponentModel.DataAnnotations;
using trabalho_np1_pedido.Common.Enum;

namespace trabalho_np1_pedido.Application.Dto
{
    public class OrderStatusUpdateDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public OrderStatus Status { get; set; }
    }
}
