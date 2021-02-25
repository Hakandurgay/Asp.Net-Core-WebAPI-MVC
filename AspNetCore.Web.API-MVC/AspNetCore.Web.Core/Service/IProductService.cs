using AspNetCore.Web.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Web.Core.Service
{
   public interface IProductService : IServiceGeneric<Product>
    {
             Task<Product> GetWithCategoryByIdAsync(int productId);
        //eğer veritabanını ilgilendirmeyen fonksiyonlar varsa service tarafında tanımlanır.
        //mesela
        //bool ControlInnerBarcode(Product product);
    }
}
