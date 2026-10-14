using ColmadoYa.Domain.Common;


namespace ColmadoYa.Domain.Entities
{
    public class Colmado : BaseEntity
    {
        public string Nombre { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string? Telefono { get; set; }
        public bool EstaAbierto { get; set; } = true;

        public int DuenoId { get; set; }
        public Usuario Dueno { get; set; } = null!;

        public ICollection<Producto> Productos { get; set; } = new List<Producto>();
        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}
