using ColmadoYa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ColmadoYa.Infrastructure.Persistence.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(u => u.Nombre).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(150);
            builder.Property(u => u.PasswordHash).IsRequired().HasMaxLength(500);
            builder.Property(u => u.Telefono).HasMaxLength(20);

            builder.HasIndex(u => u.Email).IsUnique();

            // Un usuario con rol Colmado es dueño de un solo colmado
            builder.HasOne(u => u.Colmado)
                   .WithOne(c => c.Dueno)
                   .HasForeignKey<Colmado>(c => c.DuenoId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.Pedidos)
                   .WithOne(p => p.Cliente)
                   .HasForeignKey(p => p.ClienteId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
