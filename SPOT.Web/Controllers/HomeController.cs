using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SPOT.Data;
using SPOT.Entity;
using SPOT.Web.Models;
using Microsoft.AspNetCore.Http;

namespace SPOT.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetAll()
        {
            int draw = 1; //Convert.ToInt32(request["draw"]);
            int start = 0; //Convert.ToInt32(Request["start"]);
            int length = 10; // Convert.ToInt32(Request["length"]);
            int orderColumn = 0; //Convert.ToInt32(Request["order[0][column]"]);
            string orderDir = "asc"; //Request["order[0][dir]"];
            string searchValue = ""; // Request["search[value]"];

            List<ProveedorBE> list = new ProveedorDA().GetAll();

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

            return Json(new { data = list, draw = draw, recordsTotal = listCount, recordsFiltered = filterCount });
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
