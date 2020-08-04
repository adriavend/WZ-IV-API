using System;
using System.Collections.Generic;

namespace WlZ.Products.Api.Models.Entities
{
    public partial class Product
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
        public int Idsubcategory { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Subcategory IdsubcategoryNavigation { get; set; }
    }
}
