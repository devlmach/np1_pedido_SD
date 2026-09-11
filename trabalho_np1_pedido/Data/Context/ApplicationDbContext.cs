using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using trabalho_np1_pedido.Application.Dto;
using trabalho_np1_pedido.Domain.Entity;

namespace trabalho_np1_pedido.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .Property(s => s.Products)
                .HasColumnType("text")
                .HasConversion(
                        itens => JsonSerializer.Serialize(itens, (JsonSerializerOptions)null),
                        json => JsonSerializer.Deserialize<List<ProductItemDto>>(json, (JsonSerializerOptions)null));

            modelBuilder.Entity<Order>()
                .Property(s => s.OrderStatus)
                .HasColumnType("text")
                .HasConversion<string>();   

            base.OnModelCreating(modelBuilder);
        }
        }
}
