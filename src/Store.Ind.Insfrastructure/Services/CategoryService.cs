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
    public class CategoryService : ICategoryService
    {
        private readonly ILogger<CategoryService> _logger;
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public CategoryService(ILogger<CategoryService> logger, IRepository repo, IMapper mapper)
        {
            _logger = logger;
            _repo = repo;
            _mapper = mapper;
        }
        public async Task Create(CategoryDto categoryDto)
        {
            try
            {
                var product =
                    _mapper.Map<CategoryDto, Category>(categoryDto);

                await _repo.Add(product);

                //_logger.LogInfo($"Created new Article in ArticleService. ID: {articleEntity.Id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unable to create new Article in ArticleService.");
            }
        }

        public async Task<CategoryDto> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<CategoryDto>> ListAll()
        {
            try
            {
                var categories = await _repo.List<Category>();
                return _mapper.Map<IList<Category>, IList<CategoryDto>>(categories);
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
