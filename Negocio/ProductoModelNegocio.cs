using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Datos;

namespace Negocio
{
    public class ProductoModelNegocio
    {
        ProductoModel productoModel = new ProductoModel();
        public List<ProductoModel> ObtenerProductos()
        {
            var model = productoModel.ObtenerProductos();
            return model;
        }

        public ProductoModel ObtenerProducto(int id)
        {
            var model = productoModel.ObtenerProducto(id);
            return model;
        }

        public void AgregarProducto(ProductoModel model)
        {
            model.Agregar(model);
        }
        public void EditarProducto(ProductoModel model)
        {
            model.Editar(model);
        }
        public void BorrarProducto(ProductoModel model)
        {
            model.Borrar(model);
        }

    }
}
