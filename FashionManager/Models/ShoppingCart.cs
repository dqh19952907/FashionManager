using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FashionManager.Models;
namespace FashionManager.Models
{
    public class ShoppingCart
    {
        FashionMangerEntities db = new FashionMangerEntities();
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ImageLink { get; set; }
        public int Quantity { get; set; }
        public double Price1 { get; set; }
        public double Amount
        {
            get { return Quantity * Price1; }
        }
        public ShoppingCart(int iProductID)
        {
            ProductID = iProductID;
            Product prd = db.Product.Single(n => n.ProductID == iProductID);
            Name = prd.Name;
            ImageLink = prd.ImageLink;
            Price1 = double.Parse(prd.Price1.ToString());
            Quantity = 1;
        }
    }
}