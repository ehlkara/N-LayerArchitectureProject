﻿using AutoMapper;
using NLayerArchitecture.Core;
using NLayerArchitecture.Core.DTOs;
using NLayerArchitecture.Core.Repositories;
using NLayerArchitecture.Core.Services;
using NLayerArchitecture.Core.UnitOfWorks;

namespace NLayerArchitecture.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;



        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductWithCategoryDto>> GetProductWithCategory()
        {
            var products = await _productRepository.GetProductWithCategory();

            var productsDto = _mapper.Map<List<ProductWithCategoryDto>>(products);
            return productsDto;
        }
    }
}
