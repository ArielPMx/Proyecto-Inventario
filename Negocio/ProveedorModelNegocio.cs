using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class ProveedorModelNegocio
    {
        ProveedorModel proveedorModel = new ProveedorModel();
        public List<ProveedorModel> ObtenerProveedores()
        {
            var model = proveedorModel.ObtenerProveedores();
            return model;
        }

        public ProveedorModel ObtenerProveedor(int id)
        {
            var model = proveedorModel.ObtenerProveedor(id);
            return model;
        }

        public void AgregarProveedor(ProveedorModel model)
        {
            model.Agregar(model);
        }
        public void EditarProveedor(ProveedorModel model)
        {
            model.Editar(model);
        }
        public void BorrarProveedor(ProveedorModel model)
        {
            model.Borrar(model);
        }
    }
}
