using System;
using System.Collections.Generic;

namespace WlZ.Products.Api.Models.Entities
{
    public partial class OrderDetails
    {
        public int Id { get; set; }
        public int IdOrder { get; set; }
        public int IdProduct { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Subtotal { get; set; }

        public virtual Order IdOrderNavigation { get; set; }
        public virtual Product IdProductNavigation { get; set; }
    }
}
