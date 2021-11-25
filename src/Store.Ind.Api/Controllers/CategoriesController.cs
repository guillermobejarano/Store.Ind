using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.Ind.Api.Model.Category;
using Store.Ind.Insfrastructure.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.Ind.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly ICategoryService _service;

        public CategoriesController(ILogger<CategoriesController> logger, ICategoryService service)
        {
            _logger = logger;
            _service = service;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<IEnumerable<object>> Get()
        {
            return await _service.ListAll();
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task Post([FromBody] CategoryModel category)
        {
            await _service.Create(new Domain.Dtos.CategoryDto
            {
                Name = category.Name
            });
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
