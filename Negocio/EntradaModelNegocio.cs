using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class EntradaModelNegocio
    {
        public EntradaModel entradaModel = new EntradaModel();
        public StockModelNegocio stockNegocio = new StockModelNegocio();
        public Filtro filtroNegocio = new Filtro();

        public List<EntradaModel> ObtenerEntradas()
        {
            var model = entradaModel.ObtenerEntradas();
            return model;
        }
        public EntradaModel ObtenerEntrada(int id)
        {
            var model = entradaModel.ObtenerEntrada(id);
            return model;
        }
        public void AgregarEntrada(EntradaModel model)
        {
            model.Agregar(model);
            if (stockNegocio.ProductoRegistrado(model._productoId))
            {
                var stock = stockNegocio.ObtenerStockPorProducto(model._productoId);
                stock = stockNegocio.EntradaStock(stock._stockId, model._cantidad);
                stockNegocio.EditarStock(stock);
            }
            else
            {
                StockModel stock = new StockModel();
                stock._productoId = model._productoId;
                stock._cantidad = model._cantidad;
                stockNegocio.AgregarStock(stock);
            }
        }
        public void EditarEntrada(EntradaModel model)
        {
            model.Editar(model);
        }
        public void BorrarEntrada(EntradaModel model)
        {
            model.Borrar(model);
        }

        public EntradaModel HacerEntrada()
        {
            return entradaModel.HacerEntrada();
        }

        public List<EntradaModel> FiltrarEntradas(Filtro filtro)
        {
            var model = entradaModel.ObtenerEntradas();

            if(filtro.producto != 0 && filtro.proveedor != 0)
            {
                model = model.Where(x => x._fechaEntrada >= filtro.from && x._fechaEntrada <= filtro.to 
                && x._productoId == filtro.producto && x._proveedorId == filtro.proveedor).ToList();
            }

            else if(filtro.producto != 0 && filtro.proveedor == 0) // solo filtra por producto
            {
                model = model.Where(x => x._fechaEntrada >= filtro.from && x._fechaEntrada <= filtro.to && x._productoId == filtro.producto).ToList();
            }

            else if (filtro.proveedor != 0 && filtro.producto == 0) // solo filtra por proveedor
            {
                model = model.Where(x => x._fechaEntrada >= filtro.from && x._fechaEntrada <= filtro.to && x._proveedorId == filtro.proveedor).ToList();
            }

            return model;
        }
    
    
    }
}
