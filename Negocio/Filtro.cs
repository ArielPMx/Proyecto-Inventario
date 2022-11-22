using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Filtro
    {
        public int cliente { get; set; }
        public int producto { get; set; }
        public int proveedor { get; set; }
        public DateTime from { get; set; }
        public DateTime to { get; set; }
    }
}
