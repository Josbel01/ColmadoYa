using ColmadoYa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ColmadoYa.Infrastructure.Persistence.Configurations
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.Property(c => c.Nombre).IsRequired().HasMaxLength(80);
            builder.HasIndex(c => c.Nombre).IsUnique();

            builder.HasMany(c => c.Productos)
                   .WithOne(p => p.Categoria)
                   .HasForeignKey(p => p.CategoriaId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
