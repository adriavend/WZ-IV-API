using System;
using System.Collections.Generic;

namespace WlZ.Products.Api.Models.Entities
{
    public partial class Subcategory
    {
        public Subcategory()
        {
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Idcategory { get; set; }

        public virtual Category IdcategoryNavigation { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
