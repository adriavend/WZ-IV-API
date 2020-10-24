using Microsoft.EntityFrameworkCore;
using WlZ.Products.Api.Models.Entities;
using WlZ.Products.Api.Data.Repositories.Interfaces;

namespace WlZ.Products.Api.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {

        }
    }
}
