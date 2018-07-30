using SPOT.Business;
using SPOT.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SPOT.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAll()
        {
            int draw = Convert.ToInt32(Request["draw"]);
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            int orderColumn = Convert.ToInt32(Request["order[0][column]"]);
            string orderDir = Request["order[0][dir]"];
            string searchValue = Request["search[value]"];

            List<ProveedorBE> list = new ProveedorBL().GetAll();

            int listCount = list.Count();

            if (!string.IsNullOrEmpty(searchValue))
            {
                list = list.
                    Where(x =>
                    x.IdProveedor.ToString().ToLower().Contains(searchValue.ToLower()) ||
                    x.RUC.ToLower().Contains(searchValue.ToLower()) ||
                    x.Proveedor.ToLower().Contains(searchValue.ToLower()) ||
                    x.Contacto.ToLower().Contains(searchValue.ToLower()) ||
                    x.Direccion.ToString().Contains(searchValue.ToLower())
                ).ToList();
            }

            int filterCount = list.Count;

            switch (orderColumn)
            {
                case 0: //IdProveedor
                    list = orderDir == "asc" ? list.OrderBy(x => x.IdProveedor).ToList() : list.OrderByDescending(x => x.IdProveedor).ToList();
                    break;
                case 1: //RUC
                    list = orderDir == "asc" ? list.OrderBy(x => x.RUC).ToList() : list.OrderByDescending(x => x.RUC).ToList();
                    break;
                case 2: //Proveedor
                    list = orderDir == "asc" ? list.OrderBy(x => x.Proveedor).ToList() : list.OrderByDescending(x => x.Proveedor).ToList();
                    break;
                case 3: //Contacto
                    list = orderDir == "asc" ? list.OrderBy(x => x.Contacto).ToList() : list.OrderByDescending(x => x.Contacto).ToList();
                    break;
                case 4: //Direccion
                    list = orderDir == "asc" ? list.OrderBy(x => x.Direccion).ToList() : list.OrderByDescending(x => x.Direccion).ToList();
                    break;
            }

            list = list.Skip(start).Take(length).ToList();

            return Json(new { data = list, draw = draw, recordsTotal = listCount, recordsFiltered = filterCount }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}