using AspNetCore.Web.Core.Models;
using AspNetCore.Web.MVC.DTOs;
using AutoMapper;

namespace AspNetCore.Web.MVC.Mapping
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

            CreateMap<Product, ProductWithCategoryDto>();
            CreateMap<ProductWithCategoryDto, Product>();
        }

    }
}
