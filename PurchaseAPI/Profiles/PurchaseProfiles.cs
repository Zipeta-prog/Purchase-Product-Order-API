using PurchaseAPI.Entities.Dto;
using PurchaseAPI.Entities;
using System.Net.Sockets;
using PurchaseAPI.Models;
using AutoMapper;

namespace PurchaseAPI.Profiles
{
    public class PurchaseProfiles : Profile
    {
        public PurchaseProfiles()
        {
            CreateMap<AddProductDto, Product>().ReverseMap();
            CreateMap<AddOrderDto, Order>();
            CreateMap<ProductResponseDto, Product>().ReverseMap();
            CreateMap<AddUserDto, User>().ReverseMap();
        }
    }
}
