using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;
using Datos;

namespace Inventario.Controllers
{
    public class ProductoController : Controller
    {
        ProductoModelNegocio productoNegocio = new ProductoModelNegocio();

        // GET: Producto
        public ActionResult Index()
        {
            return View(productoNegocio.ObtenerProductos());
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(ProductoModel model)
        {
            productoNegocio.AgregarProducto(model);
            return RedirectToAction("Index", "Producto");
        }

        public ActionResult Editar(int id)
        {
            return View(productoNegocio.ObtenerProducto(id));
        }

        [HttpPost]
        public ActionResult Editar(ProductoModel model)
        {
            productoNegocio.EditarProducto(model);
            return RedirectToAction("Index", "Producto");
        }

        public ActionResult Borrar(int id)
        {
            return View(productoNegocio.ObtenerProducto(id));
        }

        [HttpPost]
        public ActionResult Borrar(ProductoModel model)
        {
            productoNegocio.BorrarProducto(model);
            return RedirectToAction("Index", "Producto");
        }
    }
}