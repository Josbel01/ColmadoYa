using ColmadoYa.Domain.Common;


namespace ColmadoYa.Domain.Entities
{
    public class DetallePedido : BaseEntity
    {
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; } = null!;

        public int ProductoId { get; set; }
        public Producto Producto { get; set; } = null!;

        public decimal Subtotal => Cantidad * PrecioUnitario;
    }
}
