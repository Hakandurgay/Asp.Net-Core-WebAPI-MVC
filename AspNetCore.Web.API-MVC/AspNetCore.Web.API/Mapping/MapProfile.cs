using AspNetCore.Web.API.DTOs;
using AspNetCore.Web.Core.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.Web.API.Mapping
{
    public class MapProfile:Profile
    {

        public MapProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryWithProductDto>();
            CreateMap<CategoryWithProductDto, Category>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
        }

    }
}
