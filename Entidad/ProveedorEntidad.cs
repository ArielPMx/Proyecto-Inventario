using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class ProveedorEntidad
    {
        public int proveedorId { get; set; }
        public string rncCedula { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public bool esRnc { get; set; }
        public ICollection<EntradaEntidad> entradaEntidad { get; set; }

    }
}
