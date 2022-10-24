using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EntradaEntidad
    {
        public int entradaId { get; set; }
        public int productoId { get; set; }
        public int proveedorId { get; set; }
        public int cantidad { get; set; }
        public decimal precioUnitario { get; set; }
        public DateTime fechaEntrada { get; set; }
        public ProductoEntidad producto { get; set; }
        public ProveedorEntidad proveedor { get; set; }

    }
}
