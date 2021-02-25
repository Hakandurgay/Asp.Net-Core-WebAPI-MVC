using AspNetCore.Web.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Web.Core.UnitOfWorks
{
   public interface IUnitOfWork
    {
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }

        Task CommitAsync();
        void Commit();
    }
}
