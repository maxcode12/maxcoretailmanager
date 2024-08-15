using AutoMapper;
using MaxCoRetailManager.Application.DTOs.UserDTO;
using MaxCoRetailManager.Core.Entities;

namespace MaxCoRetailManager.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //#region Product Mapping
        //CreateMap<Product, ProductCreateDto>().ReverseMap();
        //CreateMap<Product, ProductDeleteDto>().ReverseMap();
        //CreateMap<Product, ProductGetDto>().ReverseMap();
        //CreateMap<Product, ProductUpdateDto>().ReverseMap();
        //#endregion

        CreateMap<User, UserCreateDto>()
           .ForMember(member => member.Password,
           opt => opt.Ignore())
           .ReverseMap();
        CreateMap<User, UserGetDto>().ReverseMap();

    }
}
