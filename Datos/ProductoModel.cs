using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ProductoModel
    {
        InventarioEntities _entities = new InventarioEntities();
        StockModel stockModel = new StockModel();
        public int _productoId { get; set; }
        public string _nombre { get; set; }
        public decimal _precio { get; set; }
        public int _cantidad { get; set; }

        public ICollection<Entrada> _entradas { get; set; }
        public ICollection<Facturacion> _facturacion { get; set; }
        public ICollection<Stock> _stock { get; set; }
        public ICollection<StockFacturacion> _stockFacturacion { get; set; }

        public List<ProductoModel> ObtenerProductos()
        {
            var model = _entities.Productos.Select(data => new ProductoModel
            {
                _productoId = data.ProductoID,
                _precio = data.Precio.Value,
                _nombre = data.Nombre,
                _entradas = data.Entrada,
                _stock = data.Stock,
            }).ToList();
            return model;
        }

        public void Agregar(ProductoModel model)
        {
            Productos productos = new Productos();
            productos.Nombre = model._nombre;
            productos.Precio = model._precio;
            _entities.Productos.Add(productos);
            _entities.SaveChanges();
        }

        public ProductoModel ObtenerProducto(int id)
        {
            var model = _entities.Productos.Where(x => x.ProductoID == id).Select(data => new ProductoModel
            {
                _productoId = data.ProductoID,
                _precio = data.Precio.Value,
                _nombre = data.Nombre,
                _entradas = data.Entrada,
                _stock = data.Stock,
            }).FirstOrDefault();
            return model;
        }

        public void Editar(ProductoModel model)
        {
            Productos productos = _entities.Productos.Find(model._productoId);
            productos.Nombre = model._nombre;
            productos.Precio = model._precio;
            _entities.SaveChanges();
        }

        public void Borrar(ProductoModel model)
        {
            Productos productos = _entities.Productos.Find(model._productoId);
            _entities.Productos.Remove(productos);
            _entities.SaveChanges();
        }
    
        public string ObtenerNombreProductoPorId(int id)
        {
            var model = ObtenerProducto(id);
            return model._nombre;
        }

        public List<ProductoModel> ObtenerProductosEnStock()
        {
            var model = ObtenerProductos();
            model = model.Where(x => x._stock.Count > 0).ToList();
            return model;
        }
    }
}
