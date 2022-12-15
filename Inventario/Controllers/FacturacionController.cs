using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datos;
using Negocio;

namespace Inventario.Controllers
{
    public class FacturacionController : Controller
    {
        FacturacionModelNegocio facturacionNegocio = new FacturacionModelNegocio();
        FacturacionModel facturacion = new FacturacionModel();
        ClienteModel cliente = new ClienteModel();
        ProductoModel productoModel = new ProductoModel();

        // GET: Facturacion
        public ActionResult Index()
        {
            facturacion._facturaciones = facturacionNegocio.ObtenerFacturas();
            facturacion._clientesModel = cliente.ObtenerClientes();
            return View(facturacion);
        }
        [HttpPost]
        public ActionResult Index(Filtro filtro)
        {
            facturacion._facturaciones = facturacionNegocio.FiltrarFacturas(filtro);
            facturacion._clientesModel = cliente.ObtenerClientes();
            return View(facturacion);
        }

        public ActionResult VerFactura(int id)
        {
            return View(facturacion.ObtenerFacturacion(id));
        }

        public ActionResult Nuevo()
        {
            FacturacionModel model = new FacturacionModel();
            model._cantidad = 0;
            model._clientesModel = cliente.ObtenerClientes();
            return View(model);
        }

        [HttpPost]
        public ActionResult Nuevo(FacturacionModel model, List<ProductoModel> producto)
        {
            if(producto != null)
            {
                producto = facturacionNegocio.buscarProductos(producto);
                model = facturacionNegocio.Cotizar(producto, model._clienteId);
                
                return View("Cotizar", model);
            }
            else
            {
                model._productosModel = productoModel.ObtenerProductosEnStock();
                model._clientesModel = cliente.ObtenerClientes();
                return View(model);
            }
        }

        public ActionResult Cotizar(FacturacionModel model)
        {
            return View(model);
        }

        [HttpPost]
        public ActionResult Facturar(FacturacionModel model)
        {
            facturacionNegocio.AgregarFacturacion(model);
            return RedirectToAction("Index", "Facturacion");
        }

    }
}