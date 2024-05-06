using AutoMapper;
using BtkApiProject.Common.DTOs.Categories;
using BtkApiProject.Common.DTOs.Orders;
using BtkApiProject.Common.DTOs.Products;
using BtkApiProject.Common.DTOs.Joins;
using BtkApiProject.Domain.Entities;
using BtkApiProject.Domain.Entities.Joins;

namespace BtkApiProject.Application.AutoMapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Product, ProductRequestDTO>().ReverseMap();
        CreateMap<Product, ProductResponseDTO>().ReverseMap();
        CreateMap<ProductDetail, ProductDetailRequestDTO>().ReverseMap();
        CreateMap<ProductDetail, ProductDetailResponseDTO>().ReverseMap();
        CreateMap<OrderProduct, OrdersForProductDTO>().ReverseMap();
        CreateMap<Category, CategoryResponseForProductDTO>().ReverseMap();
        CreateMap<Order, OrderResponseForProductDTO>().ReverseMap();
    }
}
