using ColmadoYa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ColmadoYa.Infrastructure.Persistence.Configurations
{
    public class DetallePedidoConfiguration : IEntityTypeConfiguration<DetallePedido>
    {
        public void Configure(EntityTypeBuilder<DetallePedido> builder)
        {
            builder.Property(d => d.PrecioUnitario).HasPrecision(18, 2);

            builder.HasOne(d => d.Producto)
                   .WithMany()
                   .HasForeignKey(d => d.ProductoId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
