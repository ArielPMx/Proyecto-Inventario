using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ClienteModel
    {
        InventarioEntities _entities = new InventarioEntities();
        public int _clienteId { get; set; }
        public int _categoriaId { get; set; }
        public string _categoria { get; set; }
        public string _rncCedula { get; set; }
        public string _nombre { get; set; }
        public string _telefono { get; set; }
        public string _email { get; set; }
        public bool _esRnc { get; set; }

        public IEnumerable<Categoria> _categorias { get; set; }
        public ICollection<Facturacion> _facturacion { get; set; }
        public List<ClienteModel> ObtenerClientes()
        {
            
            var model = _entities.Cliente.Select(data => new ClienteModel
            {
                _clienteId = data.ClienteID,
                _categoriaId = data.CategoriaID.Value,
                _categoria = data.Categoria.Descripcion,
                _rncCedula = data.RNCCedula,
                _nombre = data.Nombre,
                _facturacion = data.Facturacion,
                _telefono = data.Telefono,
                _email = data.Email,
                _esRnc = data.EsRNC.Value
            }).ToList();
            return model;
        }
        public void Agregar(ClienteModel model)
        {
            Cliente cliente = new Cliente();
            cliente.Nombre = model._nombre;
            cliente.CategoriaID = model._categoriaId;
            cliente.RNCCedula = model._rncCedula;
            cliente.Telefono = model._telefono;
            cliente.Email = model._email;
            cliente.EsRNC = model._esRnc;
            _entities.Cliente.Add(cliente);
            _entities.SaveChanges();
        }
        public ClienteModel ObtenerCliente(int id)
        {
            var model = _entities.Cliente.Where(x => x.ClienteID == id).Select(data => new ClienteModel
            {
                _clienteId = data.ClienteID,
                _rncCedula = data.RNCCedula,
                _categoria = data.Categoria.Descripcion,
                _categoriaId = data.CategoriaID.Value,
                _nombre = data.Nombre,
                _facturacion = data.Facturacion,
                _telefono = data.Telefono,
                _email = data.Email,
                _esRnc = data.EsRNC.Value
            }).FirstOrDefault();

            model._categorias = _entities.Categoria.ToList();

            return model;
        }
        public void Editar(ClienteModel model)
        {
            Cliente cliente = _entities.Cliente.Find(model._clienteId);
            cliente.RNCCedula = model._rncCedula;
            cliente.CategoriaID = model._categoriaId;
            cliente.Nombre = model._nombre;
            cliente.Telefono = model._telefono;
            cliente.Email = model._email;
            cliente.EsRNC = model._esRnc;
            _entities.SaveChanges();
        }
        public void Borrar(ClienteModel model)
        {
            Cliente cliente = _entities.Cliente.Find(model._clienteId);
            _entities.Cliente.Remove(cliente);
            _entities.SaveChanges();
        }
        public ClienteModel HacerNuevoCliente()
        {
            ClienteModel cliente = new ClienteModel();
            cliente._categorias = _entities.Categoria.ToList();
            return cliente;
        }
    }
}
