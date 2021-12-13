using AutoMapper;
using BusinessLayer.DataTransferObjects;
using BusinessLayer.DataTransferObjects.Filters;
using BusinessLayer.DataTransferObjects.QueryDTOs;
using Domain.Entities;
using Infrastructure.Persistence.Query;

namespace BusinessLayer;

public static class MappingConfig
{
    public static void ConfigureMap(IMapperConfigurationExpression config)
    {
        config.CreateMap<UserPhoto, UserPhotoDto>().ReverseMap();
        config.CreateMap<Preferences, PreferencesDto>().ReverseMap();
        config.CreateMap<User, UserDto>().ReverseMap();
        config.CreateMap<User, UserRegistrationDto>().ReverseMap();
        config.CreateMap<QueryResult<User>, QueryResultDto<UserDto, UserFilterDto>>().ReverseMap();
    }
}