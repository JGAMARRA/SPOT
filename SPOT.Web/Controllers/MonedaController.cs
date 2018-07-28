using Microsoft.AspNetCore.Mvc;
using SPOT.Business;
using SPOT.Web.Models;

namespace SPOT.Web.Controllers
{
    public class MonedaController : Controller
    {
        public IActionResult Index()
        {            
            MonedaBN obj = new MonedaBN();            
            MonedaView ov = new MonedaView();
            ov.listaMonedas= obj.getAllMoneda();
            return View(ov);
        }

        public JsonResult GetAll() {
            MonedaBN obj = new MonedaBN();
            MonedaView ov = new MonedaView();
            ov.listaMonedas = obj.getAllMoneda();
            return Json(ov);
        }
    }
}