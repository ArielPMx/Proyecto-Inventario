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
    
    public partial class StockFacturacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StockFacturacion()
        {
            this.DetalleStockFacturacion = new HashSet<DetalleStockFacturacion>();
        }
    
        public int StockFacturacionID { get; set; }
        public Nullable<int> StockID { get; set; }
        public Nullable<int> FacturacionID { get; set; }
        public Nullable<decimal> Precio { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleStockFacturacion> DetalleStockFacturacion { get; set; }
        public virtual Facturacion Facturacion { get; set; }
        public virtual Stock Stock { get; set; }
    }
}
