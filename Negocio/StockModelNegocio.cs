using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class StockModelNegocio
    {
        StockModel stockModel = new StockModel();
        public List<StockModel> ObtenerStocks()
        {
            var model = stockModel.ObtenerStocks();
            return model;
        }
        public StockModel ObtenerStock(int id)
        {
            var model = stockModel.ObtenerStock(id);
            return model;
        }
        public void AgregarStock(StockModel model)
        {
            model.Agregar(model);
        }
        public void EditarStock(StockModel model)
        {
            model.Editar(model);
        }
        //Verificar si el producto esta registrado en el stock
        public bool ProductoRegistrado(int producto)
        {
            return stockModel.EstaRegistradoProducto(producto);
        }
        //Entrar cantidad a un producto registrado en el stock
        public StockModel EntradaStock(int stockId, int cantidad)
        {
            var model = stockModel.ObtenerStock(stockId);
            model._cantidad += cantidad;
            return model;
        }
        //Restar cantidad a un producto registrado en el stock
        public StockModel SacandoStock(int stockId, int cantidad)
        {
            var model = stockModel.ObtenerStock(stockId);
            model._cantidad -= cantidad;
            return model;
        }

        public StockModel ObtenerStockPorProducto(int productoId)
        {
            return stockModel.ObtenerStockPorProducto(productoId);
        }
    }
}
