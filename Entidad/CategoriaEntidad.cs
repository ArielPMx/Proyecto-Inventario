using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class CategoriaEntidad
    {
        public int categoriaID { get; set; }
        public string descripcion { get; set; }
        public ICollection<ClienteEntidad> clienteEntidad { get; set; }
    }
}
