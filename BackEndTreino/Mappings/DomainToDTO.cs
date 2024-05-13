using API.DTOs;
using AutoMapper;
using BackEndTreino.Domain.Models;
using BackEndTreino.DTOs;
using BackEndTreino.Models;
using Core.Entitites.OrderAggregate;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace BackEndTreino.Mappings
{
    public class DomainToDTO : Profile
    {
        public DomainToDTO()
        {
            CreateMap<Product, ProductDTO>()
            .ConstructUsing(src => new ProductDTO(
                src.Id,
                src.Name,
                src.Description,
                src.Price,
                src.ImgUrl,
                src.Inventory,
                src.CategoryId,
                src.CategoryName,
                src.BrandId,
                src.BrandName
                
                
            )).ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Brand, BrandDTO>().ReverseMap();
            CreateMap<Basket, BasketDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Address, AddressDTO>().ReverseMap();

        }
    }
}

