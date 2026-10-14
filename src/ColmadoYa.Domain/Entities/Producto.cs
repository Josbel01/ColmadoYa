using ColmadoYa.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ColmadoYa.Domain.Entities
{
    public class Producto : BaseEntity
    {
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string? ImagenUrl { get; set; }
        public bool EstaDisponible { get; set; } = true;

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; } = null!;

        public int ColmadoId { get; set; }
        public Colmado Colmado { get; set; } = null!;
    }
}
