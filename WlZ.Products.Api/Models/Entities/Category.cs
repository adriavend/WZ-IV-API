using System;
using System.Collections.Generic;

namespace WlZ.Products.Api.Models.Entities
{
    public partial class Category
    {
        public Category()
        {
            Subcategory = new HashSet<Subcategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Subcategory> Subcategory { get; set; }
    }
}
