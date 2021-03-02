using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Web.Core.Models;
using AspNetCore.Web.Core.Service;

namespace AspNetCore.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IServiceGeneric<Person> _personService;

        public PersonController(IServiceGeneric<Person> personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _personService.GetAllAsync();
            return Ok(persons);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Person person)
        {
            var newPerson = await _personService.AddAsync(person);
            return Ok(newPerson);
        }
    }
}
