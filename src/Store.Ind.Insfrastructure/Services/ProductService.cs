using AutoMapper;
using Microsoft.Extensions.Logging;
using Store.Ind.Domain.Dtos;
using Store.Ind.Domain.Entities;
using Store.Ind.Domain.Interfaces;
using Store.Ind.Domain.Specifications;
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
        public async Task Create(ProductDto productDto)
        {
            try
            {
                var product =
                    _mapper.Map<ProductDto, Product>(productDto);

                if (productDto.CategoryId > 0)
                {
                    var category = await _repo.GetById<Category>(productDto.CategoryId);
                    product.Category = category;
                }

                await _repo.Add(product);

                //_logger.LogInfo($"Created new Article in ArticleService. ID: {articleEntity.Id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unable to create new Article in ArticleService.");
            }
        }

        public async Task<ProductDto> GetById(int id)
        {
            try
            {
                var product = await _repo.GetById<Product>(id);
                return _mapper.Map<Product, ProductDto>(product);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<ProductDto>> ListAll()
        {
            try
            {
                 var products = await _repo.List<Product>(new ListProductsAndVariantsSpecifications());
                return _mapper.Map<IList<Product>, IList<ProductDto>>(products);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
