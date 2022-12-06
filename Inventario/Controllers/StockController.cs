using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;
using Datos;

namespace Inventario.Controllers
{
    public class StockController : Controller
    {
        StockModelNegocio stockModel = new StockModelNegocio();

        // GET: Stock
        public ActionResult Index()
        {
            return View(stockModel.ObtenerStocks());
        }

        public ActionResult VerMovimientos(int id)
        {
            return View(stockModel.ObtenerStock(id));
        }
    }
}