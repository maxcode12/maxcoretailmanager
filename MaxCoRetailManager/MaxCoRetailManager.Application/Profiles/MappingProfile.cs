﻿using AutoMapper;
using MaxCoRetailManager.Application.DTOs.CategoryDTO;
using MaxCoRetailManager.Application.DTOs.ProductDTO;
using MaxCoRetailManager.Application.DTOs.UserDTO;
using MaxCoRetailManager.Application.Specs;
using MaxCoRetailManager.Core.Entities;

namespace MaxCoRetailManager.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //#region Product Mapping
        CreateMap<Product, ProductCreateDto>().ReverseMap();
        CreateMap<Product, ProductDeleteDto>().ReverseMap();
        CreateMap<Product, ProductGetDto>().ReverseMap();
        CreateMap<Product, ProductUpdateDto>().ReverseMap();
        CreateMap<Pagination<Product>, Pagination<ProductGetDto>>().ReverseMap();
        //#endregion

        CreateMap<User, UserCreateDto>()
           .ForMember(member => member.Password,
           opt => opt.Ignore())
           .ReverseMap();
        CreateMap<User, UserGetDto>().ReverseMap();

        //#region Category Mapping
        CreateMap<Category, CategoryCreateDto>().ReverseMap();
        CreateMap<Category, CategoryDeleteDto>().ReverseMap();
        CreateMap<Category, CategoryGetDto>().ReverseMap();
        CreateMap<Category, CategoryUpdateDto>().ReverseMap();
        //#endregion

    }
}
