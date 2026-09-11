using System.ComponentModel.DataAnnotations;

namespace trabalho_np1_pedido.Application.Dto
{
    public class OrderItemUpdateDto
    {
        public string? ClientName { get; set; }
        public string? Address { get; set; }
        public List<ProductItemDto>? Products { get; set; }
    }
}
