

using AutoMapper;
using OnionArchitecture.Domain;

namespace OnionArchitecture.DTO
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {


            // we can get all the product from the database and in the response or we return product readdto
             CreateMap<Product, ProductReadDto>();




            //Created  any new record


            //Add new record int he database and we get the data from the cleint dto and we 
          //  want to convert that dto to product and save in the database


            CreateMap<ProductCreateDto, Product>();

            // we are getting data from the client and we want to update the data in the database so we need to convert that dto to product and save in the database
            CreateMap<ProductUpdateDto, Product>();
        
        }
    }
}
