using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;
using Datos;

namespace Inventario.Controllers
{
    public class ProveedorController : Controller
    {
        // GET: Proveedor
        ProveedorModelNegocio proveedorNegocio = new ProveedorModelNegocio();

        public ActionResult Index()
        {
            return View(proveedorNegocio.ObtenerProveedores());
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(ProveedorModel model)
        {
            proveedorNegocio.AgregarProveedor(model);
            return RedirectToAction("Index", "Proveedor");
        }

        public ActionResult Editar(int id)
        {
            return View(proveedorNegocio.ObtenerProveedor(id));
        }

        [HttpPost]
        public ActionResult Editar(ProveedorModel model)
        {
            proveedorNegocio.EditarProveedor(model);
            return RedirectToAction("Index", "Proveedor");
        }

        public ActionResult Borrar(int id)
        {
            return View(proveedorNegocio.ObtenerProveedor(id));
        }

        [HttpPost]
        public ActionResult Borrar(ProveedorModel model)
        {
            proveedorNegocio.BorrarProveedor(model);
            return RedirectToAction("Index", "Proveedor");
        }
    }
}