namespace NLayerArchitecture.Core.DTOs
{
    public class ProductWithCategoryDto:ProductDto
    {
        public CategoryDto? Category { get; set; }
    }
}
