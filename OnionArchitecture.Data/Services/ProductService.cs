using AutoMapper;
using OnionArchitecture.Data.Services.IServices;
using OnionArchitecture.Domain;
using OnionArchitecture.DTO;

namespace OnionArchitecture.Data.Services
{
    public class ProductService : IProductService
    {

        private readonly ApplicationDbContext _applicationDbContext;

        private readonly IMapper _mapper;

        public ProductService(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }
        public async Task<ProductReadDto> CreateProductAsync(ProductCreateDto productCreateDto)
        {
            var  product = _mapper.Map<Product>(productCreateDto);
            await _applicationDbContext.Products.AddAsync(product);
            await _applicationDbContext.SaveChangesAsync();

            //product to productreaddto


            var productReadDto = _mapper.Map<ProductReadDto>(product);
            return productReadDto;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductReadDto>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ProductReadDto> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductReadDto> UpdateProductAsync(ProductUpdateDto product)
        {
            throw new NotImplementedException();
        }
    }
}
