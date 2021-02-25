using AspNetCore.Web.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Web.Core.Repositories
{
    public interface IProductRepository:IRepositoryGeneric<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}
