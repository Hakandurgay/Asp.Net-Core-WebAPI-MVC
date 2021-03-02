using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Web.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AspNetCore.Web.API.Filters
{
    public class ValidationFilter:ActionFilterAttribute
    {
        //filterlar hataların tek bir yerden yönetilmesini ve hata tiplerinin aynı olmasını sağlar
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                ErrorDto errorDto = new ErrorDto {Status = 400};
                //errorDto.Status = 400; yerine yukarıdaki gibi yazılabilir
                IEnumerable< ModelError > modelErrors= context.ModelState.Values.SelectMany((v => v.Errors));
                
                modelErrors.ToList().ForEach(x =>
                {
                    errorDto.Errors.Add((x.ErrorMessage));
                });
                context.Result=new BadRequestObjectResult(errorDto);
  
            }
        }
    }
}
