using Microsoft.EntityFrameworkCore;
using WlZ.Products.Api.Data.Repositories.Interfaces;
using WlZ.Products.Api.Models.Entities;

namespace WlZ.Products.Api.Data.Repositories
{
    public class OrderDetailRepository : GenericRepository<OrderDetails>, IOrderDetailRepository
    {
        public OrderDetailRepository(DbContext context) : base(context)
        {

        }
    }
}
