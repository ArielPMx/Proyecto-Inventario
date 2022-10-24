using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class EntradaModel
    {
        InventarioEntities _entities = new InventarioEntities();
        public int _entradaId { get; set; }
        public int _productoId { get; set; }
        public int _proveedorId { get; set; }
        public int _cantidad { get; set; }
        public decimal _precioUnitario { get; set; }
        public DateTime _fechaEntrada { get; set; }
        public Productos _producto { get; set; }
        public Proveedor _proveedor { get; set; }
        public List<EntradaModel> _entradas { get; set; }

        public IEnumerable<Productos> _productos { get; set; }
        public IEnumerable<Proveedor> _proveedores { get; set; }

        public List<EntradaModel> ObtenerEntradas()
        {
            var model = _entities.Entrada.Select(data => new EntradaModel
            {
                _entradaId = data.EntradaID,
                _proveedorId = data.ProveedorID.Value,
                _proveedor = data.Proveedor,
                _productoId = data.ProductoID.Value,
                _producto = data.Productos,
                _cantidad = data.Cantidad.Value,
                _precioUnitario = data.PrecioUnitario.Value,
                _fechaEntrada = data.FechaEntrada.Value
            }).ToList();
            return model;
        }

        public void Agregar(EntradaModel model)
        {
            Entrada entrada = new Entrada();
            entrada.ProductoID = model._productoId;
            entrada.ProveedorID = model._proveedorId;
            entrada.Cantidad = model._cantidad;
            entrada.PrecioUnitario = model._precioUnitario;
            entrada.FechaEntrada = DateTime.Now;
            _entities.Entrada.Add(entrada);
            _entities.SaveChanges();
        }

        public EntradaModel ObtenerEntrada(int id)
        {
            var model = _entities.Entrada.Where(x => x.EntradaID == id).Select(data => new EntradaModel
            {
                _entradaId = data.EntradaID,
                _proveedorId = data.ProveedorID.Value,
                _proveedor = data.Proveedor,
                _productoId = data.ProductoID.Value,
                _producto = data.Productos,
                _cantidad = data.Cantidad.Value,
                _precioUnitario = data.PrecioUnitario.Value,
                _fechaEntrada = data.FechaEntrada.Value
            }).FirstOrDefault();

            model._productos = _entities.Productos.ToList();
            model._proveedores = _entities.Proveedor.ToList();

            return model;
        }

        public void Editar(EntradaModel model)
        {
            Entrada entrada = _entities.Entrada.Find(model._entradaId);
            entrada.ProductoID = model._productoId;
            entrada.ProveedorID = model._proveedorId;
            entrada.Cantidad = model._cantidad;
            entrada.PrecioUnitario = model._precioUnitario;
            entrada.FechaEntrada = entrada.FechaEntrada;
            _entities.SaveChanges();
        }
        public void Borrar(EntradaModel model)
        {
            Entrada entrada = _entities.Entrada.Find(model._entradaId);
            _entities.Entrada.Remove(entrada);
            _entities.SaveChanges();
        }
        public EntradaModel HacerEntrada()
        {
            EntradaModel model = new EntradaModel();
            model._productos = _entities.Productos.ToList();
            model._proveedores = _entities.Proveedor.ToList();
            model._entradas = ObtenerEntradas();
            return model;
        } 
    }
}
