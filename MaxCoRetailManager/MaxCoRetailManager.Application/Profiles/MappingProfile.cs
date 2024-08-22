using AutoMapper;
using MaxCoRetailManager.Application.DTOs.CategoryDTO;
using MaxCoRetailManager.Application.DTOs.InventoryDTO;
using MaxCoRetailManager.Application.DTOs.LocationDTO;
using MaxCoRetailManager.Application.DTOs.ProductDTO;
using MaxCoRetailManager.Application.DTOs.SaleDetailDTO;
using MaxCoRetailManager.Application.DTOs.SaleDTO;
using MaxCoRetailManager.Application.DTOs.UserDTO;
using MaxCoRetailManager.Application.Specs;
using MaxCoRetailManager.Core.Entities;

namespace MaxCoRetailManager.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region Product Mapping
        CreateMap<Product, ProductCreateDto>().ReverseMap();
        CreateMap<Product, ProductDeleteDto>().ReverseMap();
        CreateMap<Product, ProductGetDto>().ReverseMap();
        CreateMap<Product, ProductUpdateDto>().ReverseMap();
        CreateMap<Pagination<Product>, Pagination<ProductGetDto>>().ReverseMap();
        #endregion

        #region Location Mapping
        CreateMap<Location, LocationCreateDto>().ReverseMap();
        CreateMap<Location, LocationDeleteDto>().ReverseMap();
        CreateMap<Location, LocationGetDto>().ReverseMap();
        CreateMap<Location, LocationUpdateDto>().ReverseMap();
        #endregion

        #region Category Mapping
        CreateMap<Category, CategoryCreateDto>().ReverseMap();
        CreateMap<Category, CategoryDeleteDto>().ReverseMap();
        CreateMap<Category, CategoryGetDto>().ReverseMap();
        CreateMap<Category, CategoryUpdateDto>().ReverseMap();
        #endregion

        #region Sale Mapping
        CreateMap<Sale, SaleCreateDto>().ReverseMap();
        CreateMap<Sale, SaleDeleteDto>().ReverseMap();
        CreateMap<Sale, SaleGetDto>().ReverseMap();
        CreateMap<Sale, SaleUpdateDto>().ReverseMap();
        #endregion


        #region Inventory Mapping
        CreateMap<Inventory, InventoryCreateDto>().ReverseMap();
        CreateMap<Inventory, InventoryUpdateDto>().ReverseMap();
        CreateMap<Inventory, InventoryGetDto>().ReverseMap();
        #endregion


        #region Sale Details Mapping
        CreateMap<SaleDetail, SaleDetailGetDto>().ReverseMap();
        CreateMap<Pagination<SaleDetail>, Pagination<SaleDetailGetDto>>().ReverseMap();
        #endregion

        CreateMap<User, UserCreateDto>()
           .ForMember(member => member.Password,
           opt => opt.Ignore())
           .ReverseMap();
        CreateMap<User, UserGetDto>().ReverseMap();
    }
}
