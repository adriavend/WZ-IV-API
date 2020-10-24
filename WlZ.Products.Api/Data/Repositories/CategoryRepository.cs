using Microsoft.EntityFrameworkCore;
using WlZ.Products.Api.Models.Entities;
using WlZ.Products.Api.Data.Repositories.Interfaces;

namespace WlZ.Products.Api.Data.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        {

        }
    }
}
