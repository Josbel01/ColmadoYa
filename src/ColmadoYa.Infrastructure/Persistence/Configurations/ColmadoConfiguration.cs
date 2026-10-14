using ColmadoYa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ColmadoYa.Infrastructure.Persistence.Configurations
{
    public class ColmadoConfiguration : IEntityTypeConfiguration<Colmado>
    {
        public void Configure(EntityTypeBuilder<Colmado> builder)
        {
            builder.Property(c => c.Nombre).IsRequired().HasMaxLength(120);
            builder.Property(c => c.Direccion).IsRequired().HasMaxLength(250);
            builder.Property(c => c.Telefono).HasMaxLength(20);

            builder.HasMany(c => c.Productos)
                   .WithOne(p => p.Colmado)
                   .HasForeignKey(p => p.ColmadoId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Pedidos)
                   .WithOne(p => p.Colmado)
                   .HasForeignKey(p => p.ColmadoId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
