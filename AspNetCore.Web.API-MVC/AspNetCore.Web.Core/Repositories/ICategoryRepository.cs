using AspNetCore.Web.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Web.Core.Repositories
{
    public interface ICategoryRepository: IRepositoryGeneric<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);
    }
}
