using ApiMakeUpStore.Data.Dtos.Product;
using ApiMakeUpStore.Models;
using AutoMapper;

namespace ApiMakeUpStore.Profiles
{
    public class ProductProfile: Profile
    {
        
            public ProductProfile()
            {
                CreateMap<CreateProductDto, Product>();
                CreateMap<Product, ReadProductDto>();
            }
        
    }
}
