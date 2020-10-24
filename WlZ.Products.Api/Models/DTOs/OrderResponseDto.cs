using System;

namespace WlZ.Products.Api.Models.DTOs
{
    public class OrderResponseDto
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
    }
}
