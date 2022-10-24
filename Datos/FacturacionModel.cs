using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class FacturacionModel
    {
        InventarioEntities _entities = new InventarioEntities();
        public ProductoModel productoModel = new ProductoModel();
        public int _facturacionId { get; set; }
        public int _productoId { get; set; }
        public int _clienteId { get; set; }
        public int _cantidad { get; set; }
        public decimal _precio { get; set; }
        public decimal _precioConITBIS { get; set; }
        public DateTime _fechaFactura { get; set; }
        public string textDescuento { get; set; }

        public Cliente _cliente { get; set; }
        public ClienteModel _clienteModel { get; set; }
        public IEnumerable<Cliente> _clientes { get; set; }
        public IEnumerable<ClienteModel> _clientesModel { get; set; }
        public Productos _producto { get; set; }
        public IEnumerable<Productos> _productos { get; set; }
        public IEnumerable<ProductoModel> _productosModel { get; set; }
        public ICollection<StockFacturacion> stockFacturacionEntidad { get; set; }
        public ICollection<DetalleFactura> _detalleFactura { get; set; }
        public IEnumerable<DetalleFactura> _detalleFacturaList { get; set; }
        public IEnumerable<FacturacionModel> _facturaciones { get; set; }

        public List<FacturacionModel> ObtenerFacturaciones()
        {
            var model = _entities.Facturacion.Select(data => new FacturacionModel
            {
                _facturacionId = data.FacturacionID,
                _clienteId = data.ClienteID.Value,
                _cliente = data.Cliente,
                _precioConITBIS = data.PrecioConITBIS.Value,
                _fechaFactura = data.FechaFactura.Value,
                _detalleFactura = data.DetalleFactura
            }).ToList();
            return model;
        }
        public int Agregar(FacturacionModel model)
        {
            Facturacion facturacion = new Facturacion();
            facturacion.ClienteID = model._clienteId;
            facturacion.PrecioConITBIS = model._precioConITBIS;
            facturacion.FechaFactura = DateTime.Now;
            facturacion.DetalleFactura = model._detalleFactura;
            _entities.Facturacion.Add(facturacion);
            _entities.SaveChanges();
            return facturacion.FacturacionID;
        }
        public FacturacionModel ObtenerFacturacion(int id)
        {
            var model = _entities.Facturacion.Where(x => x.FacturacionID == id).Select(data => new FacturacionModel
            {
                _facturacionId = data.FacturacionID,
                _clienteId = data.ClienteID.Value,
                _cliente = data.Cliente,
                _precioConITBIS = data.PrecioConITBIS.Value,
                _fechaFactura = data.FechaFactura.Value,
                _detalleFactura = data.DetalleFactura
            }).FirstOrDefault();
            model._clientes = _entities.Cliente.ToList();
            model._productos = _entities.Productos.ToList();
            return model;
        }
        public void Editar(FacturacionModel model)
        {
            Facturacion facturacion = _entities.Facturacion.Find(model._facturacionId);
            facturacion.ClienteID = model._clienteId;
            facturacion.PrecioConITBIS = model._precioConITBIS;
            facturacion.FechaFactura = facturacion.FechaFactura;
            _entities.SaveChanges();
        }
        public void Borrar(FacturacionModel model)
        {
            Facturacion facturacion = _entities.Facturacion.Find(model._facturacionId);
            _entities.Facturacion.Remove(facturacion);
            _entities.SaveChanges();
        }

        //public void AgregarDetalleFactura(DetalleFactura model)
        //{
        //    _entities.DetalleFactura.Add(model);
        //    _entities.SaveChanges();
        //}

        public void AgregarStockFacturacion(int stockId, FacturacionModel model)
        {
            StockFacturacion facturacion = new StockFacturacion();
            facturacion.StockID = stockId;
            facturacion.FacturacionID = model._facturacionId;
            facturacion.Precio = model._precioConITBIS;
            facturacion.Fecha = DateTime.Now;
            facturacion.DetalleStockFacturacion = new List<DetalleStockFacturacion>();

            _entities.StockFacturacion.Add(facturacion);
            _entities.SaveChanges();
        }
    
        
    }
}
