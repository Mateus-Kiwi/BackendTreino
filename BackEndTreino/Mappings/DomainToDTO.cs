using AutoMapper;
using BackEndTreino.DTOs;
using BackEndTreino.Models;

namespace BackEndTreino.Mappings
{
    public class DomainToDTO : Profile
    {
        public DomainToDTO()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Brand, BrandDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>()

        .ReverseMap();
            CreateMap<Product, ProductDTO>()
        .ReverseMap();
        }
    }
}

