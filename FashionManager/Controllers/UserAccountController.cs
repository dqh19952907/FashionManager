using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionManager.Models;
namespace FashionManager.Controllers
{
    public class UserAccountController : Controller
    {
        //
        // GET: /UserAccount/
        FashionMangerEntities db = new FashionMangerEntities();
        public ActionResult Index()
        {
            return View();
        }
       [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var user = collection["email"];
            var pass = collection["password"];
            User us = db.User.FirstOrDefault(n => (n.UserName == user && n.Password == pass));
            if (us != null)
            {
                //ViewBag.ThongBao = "Đăng Nhập Thành Công";
                Session["Account"] = us;

            }
            else
            ViewBag.ThongBao = "<div class=\"warning\">Tên Đăng Nhập Hoặc Mật Khẩu Không Đúng</div>";

            return RedirectToAction("Order", "ShoppingCart");
        }
    }
}