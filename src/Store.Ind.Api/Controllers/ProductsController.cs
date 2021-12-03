using FileHelpers;
using FileHelpers.ExcelNPOIStorage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.Ind.Api.Model.Product.In;
using Store.Ind.Domain.Dtos;
using Store.Ind.Insfrastructure.Helpers;
using Store.Ind.Insfrastructure.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public async Task<IEnumerable<Domain.Dtos.ProductDto>> Get()
        {
             return await _service.ListAll();
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<Domain.Dtos.ProductDto> Get(int id)
        {
            return await _service.GetById(id);
        }

        [HttpGet("category/{id}")]
        public async Task<IEnumerable<Domain.Dtos.ProductDto>> GetByCategory(int id)
        {
            var result = await _service.ListAll();
            return result.Where(x => x.CategoryId == id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task Post(ProductModel product)
        {

            await _service.Create( new Domain.Dtos.ProductDto { 
                Name = product.Name, 
                CategoryId = product.CategoryId,
                Barcode = product.Barcode,
                CostPrice = product.CostPrice, FinalPrice = product.FinalPrice,
                CreatedAt = product.CreatedAt,
                Description = product.Description,
                //Quantity = product.Quantity,
                Variants = product.Variants
                .Select(v => new VariantDto { Color = v.Color.Code, Size = v.Size.Code, Stock = v.Stock})
                .ToList()
            });
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, ProductModel product)
        {

        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {

        }

        [HttpGet]
        [Route("export")]
        public async Task<ActionResult> Export()
        {
            var productos =  await _service.ListAll();

            var resultCSVExport = new CsvReportHelper().WhriteCSVFile(productos);

            var fileNameCSV = GetFileNameExportCsv("productos");

            return File(resultCSVExport, "application/octet-stream", fileNameCSV);
        }

        [HttpPost]
        [Route("import")]
        public async Task<IEnumerable<object>> Import(IFormFile file)
        {
            FileHelperEngine engine = new FileHelperEngine(typeof(ProductDto));

            ProductDto[] records;

            records = (ProductDto[])engine.ReadStream(
                                 new StreamReader(file.OpenReadStream()), int.MaxValue);

            // Now "records" array contains all the records in the
            // uploaded file and can be acceded like this:

            return await _service.ListAll();
        }

        private string GetFileNameExportCsv(string name)
        {
            var fechaActual = string.Format("{0}-{1}", DateTime.Now.ToString("yyyyMMdd"), DateTime.Now.ToString("HHmmss"));
            var fileNameCSV = string.Format("{0}_" + name, fechaActual);

            return fileNameCSV;
        }
    }
}
