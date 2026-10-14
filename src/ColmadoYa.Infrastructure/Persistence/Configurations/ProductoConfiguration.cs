using ColmadoYa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColmadoYa.Infrastructure.Persistence.Configurations
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.Property(p => p.Nombre).IsRequired().HasMaxLength(120);
            builder.Property(p => p.Descripcion).HasMaxLength(500);
            builder.Property(p => p.ImagenUrl).HasMaxLength(500);
            builder.Property(p => p.Precio).HasPrecision(18, 2);
        }
    }
}
