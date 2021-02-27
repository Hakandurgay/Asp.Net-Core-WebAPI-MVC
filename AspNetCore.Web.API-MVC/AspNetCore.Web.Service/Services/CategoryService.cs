using AspNetCore.Web.Core.Models;
using AspNetCore.Web.Core.Repositories;
using AspNetCore.Web.Core.Service;
using AspNetCore.Web.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Web.Service.Services
{
    public class CategoryService : ServiceGeneric<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IRepositoryGeneric<Category> repositoryGeneric):base(unitOfWork,repositoryGeneric)
        {

        }
        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
         return await   _unitOfWork.Category.GetWithProductsByIdAsync(categoryId);
        }
    }
}
