using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class ProductoEntidad
    {
        public int productoId { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }

        public ICollection<EntradaEntidad> entradas { get; set; }
        public ICollection<FacturacionEntidad> facturacion { get; set; }
        public ICollection<StockEntidad> stock { get; set; }
        public ICollection<StockFacturacionEntidad> stockFacturacion { get; set; }
    }
}
