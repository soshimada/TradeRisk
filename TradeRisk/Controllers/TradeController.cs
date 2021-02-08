using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradeRisk.Domain.Model;
using TradeRisk.Service.Interfaces;
using TradeRisk.Service.Services;

namespace TradeRisk.Controllers
{
    public class TradeController : Controller
    {
        //readonly ITrader _trade;
        //public TradeController(ITrader trade)
        //{
        //    _trade = trade;
        //}
        ITrader serviceInscricao = new TraderService();

        // GET: Trade
        public ActionResult Index()
        {          
            return View();
        }

        [HttpPost]
        public JsonResult VerificarRisco(List<Trader> lista)
        {
            
            return Json(serviceInscricao.GetRisk(lista), JsonRequestBehavior.AllowGet);
        }
    }

    public class Trade
    {
        public string Sector { get; set; }
        public string Value { get; set; }
    }
}