using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class StockFacturacionEntidad
    {
        public int stockFacturacionId { get; set; }
        public int stockId { get; set; }
        public int facturacionId { get; set; }
        public int productoId { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public DateTime fechaStockFacturacion { get; set; }

        public FacturacionEntidad facturacionEntidad { get; set; }
        public ProductoEntidad productoEntidad { get; set; }
        public StockEntidad stockEntidad { get; set; }
    }
}
