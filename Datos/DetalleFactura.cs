//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetalleFactura
    {
        public int DetalleFacturaID { get; set; }
        public Nullable<int> FacturaID { get; set; }
        public Nullable<int> ProductoID { get; set; }
        public Nullable<int> Cantidad { get; set; }
        public Nullable<decimal> PrecioUnitario { get; set; }
        public Nullable<decimal> PrecioTotal { get; set; }
    
        public virtual Facturacion Facturacion { get; set; }
        public virtual Productos Productos { get; set; }
    }
}
