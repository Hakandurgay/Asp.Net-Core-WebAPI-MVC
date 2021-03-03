using System.Collections.Generic;

namespace AspNetCore.Web.MVC.DTOs
{
    public class CategoryWithProductDto:CategoryDto
    {
        public ICollection<ProductDto> Products { get; set; }
    }
}
