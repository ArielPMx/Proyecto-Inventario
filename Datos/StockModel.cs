using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class StockModel
    {
        InventarioEntities _entities = new InventarioEntities();
        public int _stockId { get; set; }
        public int _productoId { get; set; }
        public string _producto { get; set; }
        public int _cantidad { get; set; }
        public int _max { get; set; }
        public DateTime _fechaStock { get; set; }
        public DateTime _fechaActualizacion { get; set; }

        public Productos _productos { get; set; }
        public List<Productos> _listaProductos { get; set; }
        public ICollection<StockFacturacion> _stockFacturacion { get; set; }

        public List<StockModel> ObtenerStocks()
        {
            var model = _entities.Stock.Select(data => new StockModel
            {
                _stockId = data.StockID,
                _productoId = data.ProductoID.Value,
                _producto = data.Productos.Nombre,
                _productos = data.Productos,
                _cantidad = data.Cantidad.Value,
                _fechaStock = data.FechaStock.Value,
                _fechaActualizacion = data.FechaActualizacion.Value,
                _stockFacturacion = data.StockFacturacion
            }).ToList();
            return model;
        }

        public void Agregar(StockModel model)
        {
            Stock stock = new Stock();
            stock.ProductoID = model._productoId;
            stock.Cantidad = model._cantidad;
            stock.FechaStock = DateTime.Now;
            stock.FechaActualizacion = DateTime.Now;
            _entities.Stock.Add(stock);
            _entities.SaveChanges();
        }

        public StockModel ObtenerStock(int id)
        {
            var model = _entities.Stock.Where(x => x.StockID == id).Select(data => new StockModel
            {
                _stockId = data.StockID,
                _productoId = data.ProductoID.Value,
                _producto = data.Productos.Nombre,
                _productos = data.Productos,
                _cantidad = data.Cantidad.Value,
                _fechaStock = data.FechaStock.Value,
                _fechaActualizacion = data.FechaActualizacion.Value,
                _stockFacturacion = data.StockFacturacion
            }).FirstOrDefault();
            return model;
        }

        public void Editar(StockModel model)
        {
            Stock stock = _entities.Stock.Find(model._stockId);
            stock.ProductoID = model._productoId;
            stock.Cantidad = model._cantidad;
            stock.FechaActualizacion = DateTime.Now;
            stock.FechaStock = stock.FechaStock;
            _entities.SaveChanges();
        }

        public bool EstaRegistradoProducto(int producto)
        {
            var stock = _entities.Stock.Where(x => x.ProductoID == producto).ToList();
            if (stock.Count == 0) return false;
            else return true;
        }

        public StockModel ObtenerStockPorProducto(int producto)
        {
            var model = _entities.Stock.Where(x => x.ProductoID == producto).Select(data => new StockModel
            {
                _stockId = data.StockID,
                _productoId = data.ProductoID.Value,
                _producto = data.Productos.Nombre,
                _productos = data.Productos,
                _cantidad = data.Cantidad.Value,
                _fechaStock = data.FechaStock.Value,
                _fechaActualizacion = data.FechaActualizacion.Value,
                _stockFacturacion = data.StockFacturacion
            }).FirstOrDefault();
            return model;
        }
    
        
    }
}
