using System.ComponentModel.DataAnnotations;

namespace trabalho_np1_pedido.Application.Dto
{
    public class OrderItemUpdateDto
    {
        public string? ClientName { get; set; }
        public string? Address { get; set; }
        [MinLength(1, ErrorMessage = "O pedido deve conter pelo menos um produto.")]
        public List<ProductItemDto>? Products { get; set; }
    }
}
