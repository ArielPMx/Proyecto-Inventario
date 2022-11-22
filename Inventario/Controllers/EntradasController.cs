using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;
using Datos;

namespace Inventario.Controllers
{
    public class EntradasController : Controller
    {
        EntradaModelNegocio entrada = new EntradaModelNegocio();
        EntradaModel entradaModel = new EntradaModel();

        // GET: Entrada
        public ActionResult Index()
        {
            entradaModel = entrada.HacerEntrada();
            return View(entradaModel);
        }

        [HttpPost]
        public ActionResult Index(Filtro filtro)
        {
            entradaModel = entrada.HacerEntrada();
            entradaModel._entradas = entrada.FiltrarEntradas(filtro);
            return View(entradaModel);
        }

        public ActionResult Nuevo()
        {
            return View(entrada.HacerEntrada());
        }

        [HttpPost]
        public ActionResult Nuevo(EntradaModel model)
        {
            entrada.AgregarEntrada(model);
            return RedirectToAction("Index", "Entradas");
        }

        public ActionResult Editar(int id)
        {
            return View(entrada.ObtenerEntrada(id));
        }

        [HttpPost]
        public ActionResult Editar(EntradaModel model)
        {
            entrada.EditarEntrada(model);
            return RedirectToAction("Index", "Entradas");
        }

        public ActionResult Borrar(int id)
        {
            return View(entrada.ObtenerEntrada(id));
        }

        [HttpPost]
        public ActionResult Borrar(EntradaModel model)
        {
            entrada.BorrarEntrada(model);
            return RedirectToAction("Index", "Entradas");
        }
    }
}