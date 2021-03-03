using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Web.MVC.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        public string Name { get; set; }
    }
}
