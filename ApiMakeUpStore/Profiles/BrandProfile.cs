using ApiMakeUpStore.Data.Dtos.Brand;
using ApiMakeUpStore.Models;
using AutoMapper;

namespace ApiMakeUpStore.Profiles
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<CreateBrandDto, Brand>();
            CreateMap<Brand, ReadBrandDto>();
        }

    }
}
