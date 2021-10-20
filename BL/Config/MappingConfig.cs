using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BL.DTOs;
using Domain.Entities;

namespace BL.Config
{
    class MappingConfig
    {
        public static void ConfigureMapping(IMapperConfigurationExpression config)
        {
            config.CreateMap<User, UserGetDto>().ReverseMap();
            config.CreateMap<User, UserPreviewDto>().ForMember(u => u.Photo, us => us.MapFrom(u => u.Photos.First()));
            config.CreateMap<UserPhoto, UserPhotoGetDto>().ReverseMap();
            config.CreateMap<Chat, ChatGetDto>().ReverseMap();
        }
    }
}
