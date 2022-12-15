using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class FacturacionModelNegocio
    {
        FacturacionModel facturacionModel = new FacturacionModel();
        StockModelNegocio stockNegocio = new StockModelNegocio();
        ClienteModelNegocio clienteNegocio = new ClienteModelNegocio();
        ProductoModel productoModel = new ProductoModel();

        public double ITBIS = 0.18;
        public double descuentoPremium = 0.05;

        public List<FacturacionModel> ObtenerFacturas()
        {
            return facturacionModel.ObtenerFacturaciones();
        }
        public FacturacionModel ObtenerFactura(int id)
        {
            return facturacionModel.ObtenerFacturacion(id);
        }
        public void AgregarFacturacion(FacturacionModel model)
        {
            int factura = facturacionModel.Agregar(model);

            foreach(var item in model._detalleFactura)
            {
                var stock = stockNegocio.ObtenerStockPorProducto(item.ProductoID.Value);
                stock = stockNegocio.SacandoStock(stock._stockId, item.Cantidad.Value);
                stockNegocio.EditarStock(stock);
                model._facturacionId = factura;
                facturacionModel.AgregarStockFacturacion(stock._stockId, model);
            }
        }
        public void EditarFactura(FacturacionModel model)
        {
            facturacionModel.Editar(model);
        }
        public void BorrarFactura(FacturacionModel model)
        {
            facturacionModel.Borrar(model);
        }

        public List<ProductoModel> buscarProductos(List<ProductoModel> producto)//devuelve precio de cada producto
        {
            foreach(var item in producto)
            {
                ProductoModel model = productoModel.ObtenerProducto(item._productoId);
                item._precio = model._precio;
                item._productoId = item._productoId;
                item._cantidad = item._cantidad;
            }
            return producto;
        }

        public FacturacionModel Cotizar(List<ProductoModel> producto, int cliente)
        {
            double total = 0;
            double totalITBIS = 0;
            double descuento = 0;
            string texto = "";
            var clientePremium = clienteNegocio.ObtenerCliente(cliente);
            foreach(var item in producto)
            {
                double precioPorProductos = Convert.ToDouble(item._precio) * Convert.ToDouble(item._cantidad);
                total += precioPorProductos;

            }
            if(clientePremium._categoriaId == 1)
            {
                descuento = total * descuentoPremium;
                total = total - descuento;
                texto = "Usted aplica para el 5% de descuento, ya esta incluido!";
            }
            else
            {
                texto = "Usted no aplica para descuento";
            }
            totalITBIS = total * ITBIS;
            totalITBIS += total;

            FacturacionModel facturacion = new FacturacionModel();
            facturacion._clienteId = clientePremium._clienteId;
            facturacion._clienteModel = clientePremium;
            facturacion._precio = Convert.ToDecimal(total);
            facturacion._precioConITBIS = Convert.ToDecimal(totalITBIS);
            facturacion._fechaFactura = DateTime.Now;
            facturacion.textDescuento = texto;
            facturacion._detalleFactura = new List<DetalleFactura>();

            foreach (var item in producto)
            {
                DetalleFactura detalle = new DetalleFactura();
                detalle.ProductoID = item._productoId;
                detalle.Cantidad = item._cantidad;
                detalle.PrecioTotal = item._precio;
                facturacion._detalleFactura.Add(detalle);
            }

            return facturacion;
        }

        public List<FacturacionModel> FiltrarFacturas(Filtro filtro)
        {
            var model = facturacionModel.ObtenerFacturaciones();

            if (filtro.cliente != 0)
            {
                model = model.Where(x => x._fechaFactura >= filtro.from && x._fechaFactura <= filtro.to
                && x._clienteId == filtro.cliente).ToList();
            }

            else if (filtro.cliente == 0) // solo filtra por producto
            {
                model = model.Where(x => x._fechaFactura >= filtro.from && x._fechaFactura <= filtro.to).ToList();
            }

            return model;
        }
    }
}
