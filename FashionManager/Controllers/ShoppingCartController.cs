using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionManager.Models;
namespace FashionManager.Controllers
{
    public class ShoppingCartController : Controller
    {
        //
        // GET: /ShoppingCart/
        FashionMangerEntities db = new FashionMangerEntities();
        //public List<ShoppingCart> GetShoppingCart()
        //{
        //    List<ShoppingCart> listCartItem = Session["ShoppingCart"] as List<ShoppingCart>;
        //    if (listCartItem == null)
        //    {
        //        listCartItem = new List<ShoppingCart>();
        //        Session["ShoppingCart"] = listCartItem;
        //    }
        //    return listCartItem;
        //}
        //public ActionResult ShoppingCart()
        //{
        //    if (Session["ShoppingCart"] == null)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //    List<ShoppingCart> listCartItem = GetShoppingCart();
        //    return View(listCartItem);
        //}
        //[HttpPost]
        //public JsonResult AddToCart(int iProductID)
        //{
        //    Product prd = db.Product.SingleOrDefault(n => n.ProductID == iProductID);
        //    if (prd == null)
        //    {
        //        Response.StatusCode = 404;
        //        return null;
        //    }
        //    List<ShoppingCart> listCartItem = GetShoppingCart();
        //    ShoppingCart SC = listCartItem.Find(n => n.ProductID == iProductID);
        //    if (SC == null)
        //    {
        //        SC = new ShoppingCart(iProductID);
        //        listCartItem.Add(SC);
        //    }
        //    else
        //    {
        //        SC.Quantity++;
        //    }
        //    return Json(new { cart = SC });
        //zxc}
        private int ItemAmount()
        {
            int ItemAmount = 0;
            List<ShoppingCart> listCartItem = Session["ShoppingCart"] as List<ShoppingCart>;
            if (listCartItem != null)
            {
                ItemAmount = listCartItem.Sum(n => n.Quantity);
            }
            return ItemAmount;
        }
        private double Total()
        {
            double Total = 0;
            List<ShoppingCart> listCartItem = Session["ShoppingCart"] as List<ShoppingCart>;
            if (listCartItem != null)
            {
                Total = listCartItem.Sum(n => n.Amount);
            }
            return Total;
        }
        //public ActionResult ShoppingCartPartial()
        //{
        //    ViewBag.ItemAmount = ItemAmount();
        //    ViewBag.Total = Total();
        //    List<ShoppingCart> listCartItem = (List<ShoppingCart>)Session["ShoppingCart"];
        //    return PartialView(listCartItem);
        ///asdd}
        [HttpPost]
        public JsonResult AddToCart(int iProductID)
        {
            List<ShoppingCart> listCartItem;
            if (Session["ShoppingCart"] == null)
            {
                listCartItem = new List<ShoppingCart>();
                listCartItem.Add(new ShoppingCart(iProductID));
                Session["ShoppingCart"] = listCartItem;
            }
            else
            {
                bool flag = false;
                listCartItem = (List<ShoppingCart>)Session["ShoppingCart"];
                foreach (ShoppingCart item in listCartItem)
                {
                    if (item.ProductID == iProductID)
                    {
                        item.Quantity++;
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    listCartItem.Add(new ShoppingCart(iProductID));
                    Session["ShoppingCart"] = listCartItem;
                }
            }

            int ProductID = 0;
            string Name = "";
            string ImageLink = "";
            int Quantity = 0;
            double Price1 = 0;
            double Amount = 0;
            int ItemAmount = 0;
            double Total = 0;
            

            if (Session["ShoppingCart"] != null)
            {
                List<ShoppingCart> ls = (List<ShoppingCart>)Session["ShoppingCart"];
                foreach (ShoppingCart item in ls)
                {
                    ProductID = item.ProductID;
                    Name = item.Name;
                    ImageLink = item.ImageLink;
                    Quantity = item.Quantity;
                    Price1 = item.Price1;
                    Amount = item.Amount;
                    ItemAmount += item.Quantity;
                    Total += Amount;
                }
            }
            return Json(new {value = listCartItem});
        }
        public ActionResult GetShoppingCart()
        {
            
            return PartialView("ShoppingCartPartial");
        }

        public ActionResult ListCartItem()
        {
            return View();
        }
    }
}