using AutoMapper;
using Microsoft.Extensions.Logging;
using Store.Ind.Domain.Dtos;
using Store.Ind.Domain.Entities;
using Store.Ind.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Ind.Insfrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> _logger;
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public ProductService(ILogger<ProductService> logger, IRepository repo, IMapper mapper)
        {
            _logger = logger;
            _repo = repo;
            _mapper = mapper;
        }
        public async Task CreateProductAsync(ProductDto productDto)
        {
            try
            {
                var product =
                    _mapper.Map<ProductDto, Product>(productDto);

                await _repo.Add(product);

                //_logger.LogInfo($"Created new Article in ArticleService. ID: {articleEntity.Id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unable to create new Article in ArticleService.");
            }
        }

        public async Task<ProductDto> GetProductAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<ProductDto>> ListAllProductsAsync()
        {
            try
            {
                var products = await _repo.List<Product>();
                return _mapper.Map<IList<Product>, IList<ProductDto>>(products);
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
