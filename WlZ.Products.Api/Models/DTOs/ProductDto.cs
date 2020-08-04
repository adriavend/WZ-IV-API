using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WlZ.Products.Api.Models.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Idsubcategory { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; }
        public string Subcategory { get; set; }
        public string Category { get; set; }

        //public string ActiveText => Active ? "Active" : "Inactive";
    }
}
