//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FashionManager.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public Product()
        {
            this.Order = new HashSet<Order>();
        }
    
        public int ProductID { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Price1 { get; set; }
        public Nullable<decimal> Price2 { get; set; }
        public string ProductContent { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public string ImageLink { get; set; }
        public string ImageList { get; set; }
        public Nullable<int> ProductLike { get; set; }
        public Nullable<int> ProductView { get; set; }
        public string Status { get; set; }
        public string Tags { get; set; }
        public string Gifts { get; set; }
        public string Video { get; set; }
        public Nullable<double> Total { get; set; }
        public Nullable<double> Rate_total { get; set; }
        public Nullable<double> Rate_count { get; set; }
        public string MetaKey { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public Nullable<int> IDCategory { get; set; }
        public Nullable<int> IDColor { get; set; }
        public Nullable<int> IDSize { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Color Color { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual Size Size { get; set; }
    }
}
