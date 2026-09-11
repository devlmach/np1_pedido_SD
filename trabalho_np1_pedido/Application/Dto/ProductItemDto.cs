namespace trabalho_np1_pedido.Application.Dto
{
    public class ProductItemDto
    {
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal TotalPrice { get { return ProductPrice * ProductQuantity; } }
        }
}
