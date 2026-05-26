using OnionArchitecture.DTO;

namespace OnionArchitecture.Data.Services.IServices
{
    public interface IProductService
    {
            Task<IEnumerable<ProductReadDto>> GetAllProductsAsync();
            Task<ProductReadDto> GetProductByIdAsync(int id);
            Task<ProductReadDto> CreateProductAsync(ProductCreateDto product);
            Task<ProductReadDto> UpdateProductAsync(ProductUpdateDto product);
            Task<bool> DeleteProductAsync(int id);
    }
}
