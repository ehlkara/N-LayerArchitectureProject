using NLayerArchitecture.Core.DTOs;

namespace NLayerArchitecture.Core.Services
{
    public interface IProductService : IService<Product>
    {
        Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductWithCategory();
    }
}
