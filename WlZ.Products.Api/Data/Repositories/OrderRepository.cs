﻿using Microsoft.EntityFrameworkCore;
using WlZ.Products.Api.Data.Repositories.Interfaces;
using WlZ.Products.Api.Models.Entities;

namespace WlZ.Products.Api.Data.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(DbContext context) : base(context)
        {

        }
    }
}
