using ColmadoYa.Domain.Common;
using ColmadoYa.Domain.Enums;


namespace ColmadoYa.Domain.Entities
{
    public class Pedido : BaseEntity
    {
        public EstadoPedido Estado { get; set; } = EstadoPedido.Recibido;
        public string DireccionEntrega { get; set; } = string.Empty;
        public string? Notas { get; set; }

        public int ClienteId { get; set; }
        public Usuario Cliente { get; set; } = null!;

        public int ColmadoId { get; set; }
        public Colmado Colmado { get; set; } = null!;

        public ICollection<DetallePedido> Detalles { get; set; } = new List<DetallePedido>();

        // Se calcula, no se guarda: así nunca queda desincronizado
        public decimal Total => Detalles.Sum(d => d.Subtotal);
    }
}
