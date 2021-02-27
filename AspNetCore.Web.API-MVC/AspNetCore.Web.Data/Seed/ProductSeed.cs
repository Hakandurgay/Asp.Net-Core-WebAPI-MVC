using AspNetCore.Web.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.Web.Data.Seed
{
    public class ProductSeed : IEntityTypeConfiguration<Product>  //db oluşurken ilk eklenecek değerler
    {
        private readonly int[] _ids;
        public ProductSeed(int[] ids)
        {
            _ids = ids;
        }
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(

                new Product { Id = 1, Name = "Pilot Kalem", Price = 12.50m, Stock = 100, CategoryId = _ids[0] },
                new Product { Id = 2, Name = "Kurşum Kalem", Price = 40.50m, Stock = 200, CategoryId = _ids[0] },
                new Product { Id = 3, Name = "Tükenmez Kalem", Price = 20.50m, Stock = 300, CategoryId = _ids[0] },
                new Product { Id = 4, Name = "Küçük Boy Defter", Price = 10.50m, Stock = 400, CategoryId = _ids[1] },
                new Product { Id = 5, Name = "Orta Boy Defter", Price = 5.50m, Stock = 300, CategoryId = _ids[1] },
                new Product { Id = 6, Name = "Büyük Boy Defter", Price = 7.50m, Stock = 300, CategoryId = _ids[1] }

                );
        }
    }
}
