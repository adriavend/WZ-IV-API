using System.Collections.Generic;

namespace WlZ.Products.Api.Models.DTOs
{
    public class OrderRequestDto
    {
        public string Client { get; set; }

        public List<OrderDetailRequestDto> Details { get; set; }
    }
}
