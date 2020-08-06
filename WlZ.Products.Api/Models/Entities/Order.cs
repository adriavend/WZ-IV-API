using System;
using System.Collections.Generic;

namespace WlZ.Products.Api.Models.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Id { get; set; }
        public string Client { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
