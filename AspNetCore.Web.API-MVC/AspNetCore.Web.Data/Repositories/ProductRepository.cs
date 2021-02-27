using AspNetCore.Web.Core.Models;
using AspNetCore.Web.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Web.Data.Repositories
{
    public class ProductRepository : RepositoryGeneric<Product>, IProductRepository
    {

        public AppDbContext _appDbContext { get => _context as AppDbContext; } //dbcontext appdbcontext'e çevrilmezse category ve product gelmez çünkü bunlar
                                                                              //appDbContext'te tanımlı

        public ProductRepository(DbContext context) : base(context)
        {

        }
        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
         return await _appDbContext.Products.Include(x => x.Category).SingleOrDefaultAsync(x => x.Id == productId);
        }

    }
}






