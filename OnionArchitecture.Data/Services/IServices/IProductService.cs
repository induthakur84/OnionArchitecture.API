using OnionArchitecture.DTO;

namespace OnionArchitecture.Data.Services.IServices
{

    //abstraction because we hide the implementation details of the service and we can use this interface to call the service methods in the controller without knowing how they are implemented
    public interface IProductService
    {
            Task<IEnumerable<ProductReadDto>> GetAll();
            Task<ProductReadDto> GetById(int id);
            Task<ProductReadDto> Create(ProductCreateDto product);
            Task<ProductReadDto> Update(ProductUpdateDto product);
            Task<bool> Delete(int id);

        //true

        //false
    }
}
