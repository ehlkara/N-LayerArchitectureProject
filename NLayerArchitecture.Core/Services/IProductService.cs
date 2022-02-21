using NLayerArchitecture.Core.DTOs;

namespace NLayerArchitecture.Core.Services
{
    public interface IProductService : IService<Product>
    {
        Task<List<ProductWithCategoryDto>> GetProductWithCategory();
    }
}
