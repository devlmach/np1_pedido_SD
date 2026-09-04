using System.ComponentModel.DataAnnotations;

namespace trabalho_np1_pedido.Domain.Entity.Base
{
    public class EntityBase
    {
        [Key]
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
    }
}
