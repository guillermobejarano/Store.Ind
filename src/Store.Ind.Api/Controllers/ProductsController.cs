using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.Ind.Domain.Entities;
using Store.Ind.Domain.Interfaces;
using System.Collections.Generic;

namespace Store.Ind.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IRepository _repo;

        public ProductsController(ILogger<ProductsController> logger, IRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _repo.List<Product>();
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post(Product product)
        {
            _repo.Add<Product>(product);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, Product product)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
