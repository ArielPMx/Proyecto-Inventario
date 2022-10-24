using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ProveedorModel
    {
        InventarioEntities _entities = new InventarioEntities();
        public int _proveedorId { get; set; }
        public string _rncCedula { get; set; }
        public string _nombre { get; set; }
        public string _telefono { get; set; }
        public string _email { get; set; }
        public bool _esRnc { get; set; }
        public ICollection<Entrada> _entrada { get; set; }

        public List<ProveedorModel> ObtenerProveedores()
        {
            var model = _entities.Proveedor.Select(data => new ProveedorModel
            {
                _proveedorId = data.ProveedorID,
                _rncCedula = data.RNCCedula,
                _nombre = data.Nombre,
                _entrada = data.Entrada,
                _telefono = data.Telefono,
                _email = data.Email,
                _esRnc = data.EsRNC.Value
            }).ToList();
            return model;
        }

        public void Agregar(ProveedorModel model)
        {
            Proveedor proveedor = new Proveedor();
            proveedor.Nombre = model._nombre;
            proveedor.RNCCedula = model._rncCedula;
            proveedor.Telefono = model._telefono;
            proveedor.Email = model._email;
            proveedor.EsRNC = model._esRnc;
            _entities.Proveedor.Add(proveedor);
            _entities.SaveChanges();
        }
        public ProveedorModel ObtenerProveedor(int id)
        {
            var model = _entities.Proveedor.Where(x => x.ProveedorID == id).Select(data => new ProveedorModel
            {
                _proveedorId = data.ProveedorID,
                _rncCedula = data.RNCCedula,
                _nombre = data.Nombre,
                _entrada = data.Entrada,
                _telefono = data.Telefono,
                _email = data.Email,
                _esRnc = data.EsRNC.Value
            }).FirstOrDefault();
            return model;
        }

        public void Editar(ProveedorModel model)
        {
            Proveedor proveedor = _entities.Proveedor.Find(model._proveedorId);
            proveedor.RNCCedula = model._rncCedula;
            proveedor.Nombre = model._nombre;
            proveedor.Telefono = model._telefono;
            proveedor.Email = model._email;
            proveedor.EsRNC = model._esRnc;
            _entities.SaveChanges();
        }

        public void Borrar(ProveedorModel model)
        {
            Proveedor proveedor = _entities.Proveedor.Find(model._proveedorId);
            _entities.Proveedor.Remove(proveedor);
            _entities.SaveChanges();
        }

    }
}
