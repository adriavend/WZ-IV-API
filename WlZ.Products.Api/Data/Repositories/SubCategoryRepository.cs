using Microsoft.EntityFrameworkCore;
using WlZ.Products.Api.Models.Entities;
using WlZ.Products.Api.Data.Repositories.Interfaces;

namespace WlZ.Products.Api.Data.Repositories
{
    public class SubCategoryRepository : GenericRepository<Subcategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(DbContext context) : base(context)
        {

        }
    }
}
