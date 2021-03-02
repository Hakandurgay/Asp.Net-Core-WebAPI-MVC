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
using AspNetCore.Web.API.Filters;

namespace AspNetCore.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;  //dependency injection ayarları startupta yapıldı
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

   
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }
        [ServiceFilter(typeof(NotFoundFilter))]
        //   [NotFoundFilter()]//böyle tanımlandığında product service istiyor
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product= await _productService.GetByIdAsync(id);

            return Ok(_mapper.Map<ProductDto>(product));
        }
        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetWithCategoryById(int id)
        {
            var product = await _productService.GetWithCategoryByIdAsync(id);

            return Ok(_mapper.Map<ProductWithCategoryDto>(product));
        }
        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var newProduct =await _productService.AddAsync(_mapper.Map<Product>(productDto));
            return Created(string.Empty,_mapper.Map<ProductDto>(newProduct));
        }


        [HttpPut]
        public IActionResult Update(ProductDto productDto)
        {
            var product = _productService.Update(_mapper.Map<Product>(productDto));
            return NoContent();
        }
        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _productService.GetByIdAsync(id).Result;
            _productService.Remove(product);
            return NoContent();
        }


    }
}