using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class StockEntidad
    {
        public int stockId { get; set; }
        public int productoId { get; set; }
        public int cantidad { get; set; }
        public DateTime fechaStock { get; set; }

        public ProductoEntidad productoEntidad { get; set; }
        public ICollection<StockFacturacionEntidad> stockFacturacionEntidad { get; set; }
    }
}
