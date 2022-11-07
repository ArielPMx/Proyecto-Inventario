using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;
using Datos;

namespace Inventario.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        ClienteModelNegocio clienteNegocio = new ClienteModelNegocio();

        public ActionResult Index()
        {
            return View(clienteNegocio.ObtenerClientes());
        }

        public ActionResult Nuevo()
        {
            return View(clienteNegocio.HacerCliente());
        }

        [HttpPost]
        public ActionResult Nuevo(ClienteModel model)
        {
            clienteNegocio.AgregarCliente(model);
            return RedirectToAction("Index", "Cliente");
        }

        public ActionResult Editar(int id)
        {
            return View(clienteNegocio.ObtenerCliente(id));
        }

        [HttpPost]
        public ActionResult Editar(ClienteModel model)
        {
            clienteNegocio.EditarCliente(model);
            return RedirectToAction("Index", "Cliente");
        }

        public ActionResult Borrar(int id)
        {
            return View(clienteNegocio.ObtenerCliente(id));
        }

        [HttpPost]
        public ActionResult Borrar(ClienteModel model)
        {
            clienteNegocio.BorrarCliente(model);
            return RedirectToAction("Index", "Cliente");
        }
    }
}