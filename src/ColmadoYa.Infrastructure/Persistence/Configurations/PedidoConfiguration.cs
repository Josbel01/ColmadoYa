using ColmadoYa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColmadoYa.Infrastructure.Persistence.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.Property(p => p.DireccionEntrega).IsRequired().HasMaxLength(250);
            builder.Property(p => p.Notas).HasMaxLength(500);

            // Si se borra un pedido, se borran sus detalles
            builder.HasMany(p => p.Detalles)
                   .WithOne(d => d.Pedido)
                   .HasForeignKey(d => d.PedidoId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
