using AspNetCore.Web.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Web.Core.Service
{
    public interface ICategoryService:IServiceGeneric<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);

    }
}
