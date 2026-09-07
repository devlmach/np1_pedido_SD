using System.ComponentModel.DataAnnotations;

namespace trabalho_np1_pedido.Application.Dto
{
    public class OrderItemUpdateDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string ClientName { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public List<ProductItemDto> Products { get; set; }
    }
}
