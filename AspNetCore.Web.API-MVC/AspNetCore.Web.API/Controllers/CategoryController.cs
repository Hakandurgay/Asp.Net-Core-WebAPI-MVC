using AspNetCore.Web.API.DTOs;
using AspNetCore.Web.Core.Models;
using AspNetCore.Web.Core.Service;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.Web.API.Controllers
{
    [Route("api/[controller]")]
    //[Route("api/[controller/[action]")] yazarak metod adını da girebiliriz ama böyle kullanım önerilmez
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;  //dependency injection ayarları startupta yapıldı
        private readonly IMapper _mapper;  
 
        public CategoryController(ICategoryService categoryService, IMapper mapper) //startupa Icategoryservice ile karşılaşınca categoryservice oluştur demiştik
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            //foreach(var category in categories)
            //{
            //    category.Id= gibi yapıp dto dakilere eşitlemektense automapper kütüphanesi kullanılır
            //}

            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories)); //ok, 200 durum kodu
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            return Ok(_mapper.Map<CategoryDto>(category));
        }
        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetWithProductsById(int id)
        {
            var category = await _categoryService.GetWithProductsByIdAsync(id);

            return Ok(_mapper.Map<CategoryWithProductDto>(category));
        }
        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto categoryDto)
        {
          var category=  await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
            return Created(string.Empty, _mapper.Map<CategoryDto>(category));
        }

        [HttpPut]
        public IActionResult Update(CategoryDto categoryDto)
        {
            var category = _categoryService.Update(_mapper.Map<Category>(categoryDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public  IActionResult Delete(int id)
        {
            var category = _categoryService.GetByIdAsync(id).Result;
            _categoryService.Remove(category);
            return NoContent();
        }

  

    }
}
