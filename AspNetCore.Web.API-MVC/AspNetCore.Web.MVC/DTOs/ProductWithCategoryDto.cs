﻿namespace AspNetCore.Web.MVC.DTOs
{
    public class ProductWithCategoryDto:ProductDto
    {
        public CategoryDto  Category { get; set; }
    }
}
