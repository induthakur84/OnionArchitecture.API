using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        //this is your query adding data in the data
        public async Task<ProductReadDto> Create(ProductCreateDto productCreateDto)
        {
            var  product = _mapper.Map<Product>(productCreateDto);
            await _applicationDbContext.Products.AddAsync(product);
            await _applicationDbContext.SaveChangesAsync();

            //product to productreaddto


            var productReadDto = _mapper.Map<ProductReadDto>(product);
            return productReadDto;
        }

        public async Task<bool> Delete(int id)
        {
            var product = await _applicationDbContext.Products.FindAsync(id);

            if (product == null)
            {
                return false;
            }
            _applicationDbContext.Products.Remove(product);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ProductReadDto>> GetAll()
        {
            var products = await _applicationDbContext.Products.ToListAsync();

            var productReadDtos = _mapper.Map<IEnumerable<ProductReadDto>>(products);
            return productReadDtos;
        }

        public async Task<ProductReadDto> GetById(int id)
        {
            var product= await _applicationDbContext.Products.FindAsync(id);

            if (product ==null)
            {
                return null;
            }

            var productReadDto = _mapper.Map<ProductReadDto>(product);

            return productReadDto;
        }

        public async Task<ProductReadDto> Update(ProductUpdateDto product)
        {
           var existingProduct = await _applicationDbContext.Products.FindAsync(product.Id);
            if (existingProduct == null)
            {
                return null;
            }
            _mapper.Map(product, existingProduct);
            _applicationDbContext.Products.Update(existingProduct);
            await _applicationDbContext.SaveChangesAsync();
            var productReadDto = _mapper.Map<ProductReadDto>(existingProduct);
            return productReadDto;
        }
    }
}
