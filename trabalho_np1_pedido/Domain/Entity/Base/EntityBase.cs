using System.ComponentModel.DataAnnotations;

namespace trabalho_np1_pedido.Domain.Entity.Base
{
    public class EntityBase
    {
        [Key]
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }
}
