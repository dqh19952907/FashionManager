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
        public ActionResult UpdateShoppingCart(int iProductID, FormCollection f)
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
                listCartItem = (List<ShoppingCart>)Session["ShoppingCart"];
                ShoppingCart SC = listCartItem.SingleOrDefault(n => n.ProductID == iProductID);
                if (SC != null)
                {
                    SC.Quantity = int.Parse(f["quantity"].ToString());
                }
            }
            return RedirectToAction("ListCartItem");
        }
        public ActionResult DeleteShoppingCart(int iProductID)
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
                listCartItem = (List<ShoppingCart>)Session["ShoppingCart"];
                ShoppingCart SC = listCartItem.SingleOrDefault(n => n.ProductID == iProductID);
                if (SC != null)
                {
                    listCartItem.RemoveAll(n => n.ProductID == iProductID);
                    return RedirectToAction("ListCartItem");
                }
            }
            return RedirectToAction("ListCartItem");
        }
        [HttpGet]
        public ActionResult Order()
        {
            List<ShoppingCart> listCartItem = (List<ShoppingCart>)Session["ShoppingCart"];
            if (listCartItem == null||listCartItem.Count == 0 )
            {
                return RedirectToAction("Index","Home");
            }
            return View();
        }
        [HttpPost ,ActionName("Order")]
        public ActionResult Order(FormCollection f)
        {
            
            Transaction Trans = new Transaction();
            User us = (User)Session["Account"];
            List<ShoppingCart> SC = (List<ShoppingCart>)Session["ShoppingCart"];
            Trans.IDUser = us.UserID;
            Trans.UserName = us.UserName;
            Trans.UserEmail = us.Email;
            Trans.UserPhone = us.Phone;
            Trans.Created = DateTime.Now;
            db.Transaction.Add(Trans);
            db.SaveChanges();
            foreach (var item in SC)
            {
                Order ord = new Order();
                ord.IDTransaction = Trans.TransactionID;
                ord.IDProduct = item.ProductID;
                ord.Qty= item.Quantity;
                ord.Amount = (decimal)item.Amount;
                db.Order.Add(ord);
            }
            db.SaveChanges();
            Session["ShoppingCart"] = null;
            return RedirectToAction("ConfirmOrder", "ShoppingCart");
        }
        public ActionResult ConfirmOrder()
        {
            return View();
        } 
    }
}