using AutoMapper;
using BtkApiProject.Application.Features.Queries.Products.GetAllProducts;
using BtkApiProject.Application.Features.Queries.Products.GetOneProduct;
using BtkApiProject.Application.Parameters;
using BtkApiProject.Common.DTOs.Categories;
using BtkApiProject.Common.DTOs.Joins;
using BtkApiProject.Common.DTOs.Orders;
using BtkApiProject.Common.DTOs.Products;
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
        CreateMap<ProductParameters, GetOneProductQueryRequest>().ReverseMap();
        CreateMap<ProductParameters, GetAllProductsQueryRequest>()
            .ForMember(p => p.PageNumber, o => o.MapFrom(g => g.Pagination.PageNumber))
            .ForMember(p => p.PageSize, o => o.MapFrom(g => g.Pagination.PageSize))
            .ReverseMap();
    }
}