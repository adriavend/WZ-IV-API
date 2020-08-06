using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WlZ.Products.Api.Models.DTOs
{
    public class OrderDetailResponseDto
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Subtotal { get; set; }
    }
}
