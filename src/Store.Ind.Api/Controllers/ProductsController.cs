using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.Ind.Api.Model.Product.In;
using Store.Ind.Insfrastructure.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Ind.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _service;

        public ProductsController(ILogger<ProductsController> logger, IProductService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<object>> Get()
        {
             return await _service.ListAllProductsAsync();
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task Post(ProductModel product)
        {
            await _service.CreateProductAsync( new Domain.Dtos.ProductDto { 
                Name = product.Name, 
                CategoryName = product.Category,
                Barcode = product.Barcode,
                CostPrice = product.CostPrice, FinalPrice = product.FinalPrice,
                CreatedAt = product.CreatedAt,
                Description = product.Description,
                Quantity = product.Quantity
            });
        }

        ////// PUT api/<ProductController>/5
        ////[HttpPut("{id}")]
        ////public void Put(int id, ProductModel product)
        ////{
        ////}

        ////// DELETE api/<ProductController>/5
        ////[HttpDelete("{id}")]
        ////public void Delete(int id)
        ////{
        ////}
    }
}
