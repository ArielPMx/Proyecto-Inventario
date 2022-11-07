using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class ClienteModelNegocio
    {
        ClienteModel clienteModel = new ClienteModel();
        public List<ClienteModel> ObtenerClientes()
        {
            var model = clienteModel.ObtenerClientes();
            return model;
        }
        public ClienteModel ObtenerCliente(int id)
        {
            var model = clienteModel.ObtenerCliente(id);
            return model;
        }
        public void AgregarCliente(ClienteModel model)
        {
            model.Agregar(model);
        }
        public void EditarCliente(ClienteModel model)
        {
            model.Editar(model);
        }
        public void BorrarCliente(ClienteModel model)
        {
            model.Borrar(model);
        }
        public ClienteModel HacerCliente()
        {
            return clienteModel.HacerNuevoCliente();
        }
    }
}
