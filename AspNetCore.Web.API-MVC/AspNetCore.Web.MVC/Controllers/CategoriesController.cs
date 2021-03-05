using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Web.API.Filters;
using AspNetCore.Web.Core.Models;
using AspNetCore.Web.Core.Service;
using AspNetCore.Web.MVC.ApiService;
using AspNetCore.Web.MVC.DTOs;
using AutoMapper;

namespace AspNetCore.Web.MVC.Controllers
{
    public class CategoriesController : Controller
    {
     //   private readonly ICategoryService _categoryService;
        private readonly CategoryApiService _apiService;
        private readonly IMapper _mapper;

        public CategoriesController( IMapper mapper, CategoryApiService apiService)
        {
       //     _categoryService = categoryService;
            _mapper = mapper;
            _apiService = apiService;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _apiService.GetAllAsync();

            return View(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }
        [HttpGet]

        public  IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            await _apiService.AddAsync(categoryDto);    // _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var category = await _apiService.GetByIdAsync(id);

            return View(_mapper.Map<CategoryDto>(category));
        }

        [HttpPost]
        public async Task<IActionResult> Update (CategoryDto categoryDto)
        {
           await _apiService.Update(categoryDto);

            return RedirectToAction("Index");
        }


        [ServiceFilter(typeof(NotFoundFilter))]
        public async Task<IActionResult> Delete(int id)
        {

          await  _apiService.Remove(id);

            return RedirectToAction("Index");
        }
    }
}
