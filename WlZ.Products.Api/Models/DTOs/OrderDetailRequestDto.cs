using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WlZ.Products.Api.Models.DTOs
{
    public class OrderDetailRequestDto
    {
        public int IdProduct { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
