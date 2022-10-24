using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class FacturacionEntidad
    {
        public int facturacionId { get; set; }
        public int productoId { get; set; }
        public int clienteId { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal precioConITBIS { get; set; }
        public DateTime fechaFactura { get; set; }

        public ClienteEntidad cliente { get; set; }
        public ProductoEntidad producto { get; set; }
        public ICollection<StockFacturacionEntidad> stockFacturacionEntidad { get; set; }
    }
}
