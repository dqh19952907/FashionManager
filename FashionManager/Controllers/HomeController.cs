using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionManager.Models;
namespace FashionManager.Controllers
{
    public class HomeController : Controller
    {
        FashionMangerEntities db = new FashionMangerEntities();        
        public ActionResult Index()
        {
            List<Product> lstProduct = db.Product.ToList();
            return View(lstProduct);
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