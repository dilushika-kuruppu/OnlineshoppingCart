using AutoMapper;
using OnlineShopping.Common;
using OnlineShopping.Common.CategoryDto;
using OnlineShopping.Common.OrderDto;
using OnlineShopping.Common.PaymentDto;
using OnlineShopping.Common.ProductDto;
using OnlineShopping.Data.Models;
using OnlineShoppingDB.Server.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategoryForDetailDto>();
            CreateMap<Product, ProductDetailDto>();
            CreateMap<Product, ProductDetailDto>();
            CreateMap<Payment, PaymentDto>();
            //CreateMap<OrderDto, Orders>().ForMember(des => des.OrderItem, opt => opt.MapFrom(src => src.OrderItemDto)).ReverseMap();
            CreateMap<OrderItemDto, OrderItem>()
              .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id));

            CreateMap<UserForCustomerDto, Customer>();

            CreateMap<Login, UserForLoginDto>();

       

            CreateMap<Orders, OrderInformDto>().ReverseMap();

        }
    }
}
