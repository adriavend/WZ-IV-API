using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WlZ.Products.Api.Models.DTOs
{
    public class OrderRequestDto
    {
        public string Client { get; set; }

        public List<OrderDetailRequestDto> Details { get; set; }
    }
}
