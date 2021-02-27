using AspNetCore.Web.Core.Models;
using AspNetCore.Web.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Web.Data.Repositories
{
    public class CategoryRepository : RepositoryGeneric<Category>, ICategoryRepository
    {
        private AppDbContext appDbContext { get => _context as AppDbContext; }

        public CategoryRepository(DbContext context):base(context)
        {

        }
        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            return await appDbContext.Categories.Include(x => x.Products).SingleOrDefaultAsync(x => x.Id == categoryId);
        }
    }
}
