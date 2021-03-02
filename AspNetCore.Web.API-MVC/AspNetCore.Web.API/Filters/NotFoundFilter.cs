using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Web.API.DTOs;
using AspNetCore.Web.Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetCore.Web.API.Filters
{
    public class NotFoundFilter:ActionFilterAttribute
    {
        private readonly IProductService _productService;

        public NotFoundFilter(IProductService productService)
        {
            _productService = productService;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //values actiona gelen parametrelerin değerini yakalar. bir tane değer olduğu için id yi bulmak için firstordefault kulalnıldı
            int id = (int)context.ActionArguments.Values.FirstOrDefault();

            var product = await _productService.GetByIdAsync(id);

            if (product != null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto {Status = 404};
                errorDto.Errors.Add($"id'si  {id} olan ürün veritabanında bulunamadı");
                context.Result=new NotFoundObjectResult(errorDto);
            }
        }
    }
}
