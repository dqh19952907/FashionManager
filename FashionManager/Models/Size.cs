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
    
    public partial class Size
    {
        public Size()
        {
            this.Product = new HashSet<Product>();
        }
    
        public int SizeID { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Product> Product { get; set; }
    }
}
