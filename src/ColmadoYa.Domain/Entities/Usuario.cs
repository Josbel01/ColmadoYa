using ColmadoYa.Domain.Common;
using ColmadoYa.Domain.Enums;


namespace ColmadoYa.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string? Telefono { get; set; }
        public RolUsuario Rol { get; set; }

        // Si el rol es Colmado, este usuario es dueño de un colmado
        public Colmado? Colmado { get; set; }
        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}
