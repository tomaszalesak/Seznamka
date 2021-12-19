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
        config.CreateMap<string, byte[]>().ConvertUsing<Base64Converter>();
        config.CreateMap<byte[], string>().ConvertUsing<Base64Converter>();
        config.CreateMap<UserPhoto, UserPhotoDto>().ReverseMap();
        config.CreateMap<Ban, BanDto>().ReverseMap();
        config.CreateMap<Chat, ChatDto>().ReverseMap();
        config.CreateMap<Friendship, FriendshipDto>().ReverseMap();
        config.CreateMap<Ban, BanWithUsersDto>().ReverseMap();
        config.CreateMap<Ban, BanWithUsernameDto>().ReverseMap();
        config.CreateMap<Preferences, PreferencesDto>().ReverseMap();
        config.CreateMap<User, UserDto>().ReverseMap();
        config.CreateMap<Message, MessageDto>().ReverseMap();
        config.CreateMap<UserChat, UserChatDto>().ReverseMap();
        config.CreateMap<ChatUserNameDto, UserChatDto>().ReverseMap();
        config.CreateMap<User, UserNamesDto>().ReverseMap();
        config.CreateMap<User, UserRegistrationDto>().ReverseMap();
        config.CreateMap<Friendship, FriendshipwithUsernameDto>().ReverseMap();
        config.CreateMap<QueryResult<User>, QueryResultDto<UserDto, UsernameUserFilterDto>>().ReverseMap();
        config.CreateMap<QueryResult<Message>, QueryResultDto<MessageDto, MessageFilterDto>>().ReverseMap();
        config.CreateMap<QueryResult<User>, QueryResultDto<UserDto, FindUserFilterDto>>().ReverseMap();
        config.CreateMap<QueryResult<UserPhoto>, QueryResultDto<UserPhotoDto, UserPhotoFilterDto>>().ReverseMap();
        config.CreateMap<QueryResult<Ban>, QueryResultDto<BanWithUsersDto, BannedUsersFilterDto>>().ReverseMap();
        config.CreateMap<QueryResult<Ban>, QueryResultDto<BanDto, BanFilterDto>>().ReverseMap();
        config.CreateMap<QueryResult<Friendship>, QueryResultDto<FriendshipDto, FriendshipFilterDto>>().ReverseMap();
        config.CreateMap<QueryResult<Chat>, QueryResultDto<ChatDto, ChatFilterDto>>().ReverseMap();
        config.CreateMap<QueryResult<UserChat>, QueryResultDto<UserChatDto, UserChatFilterDto>>().ReverseMap();
    }
    
    private class Base64Converter : ITypeConverter<string, byte[]>, ITypeConverter<byte[], string>
    {
        public byte[] Convert(string source, byte[] destination, ResolutionContext context) 
            => System.Convert.FromBase64String(source);

        public string Convert(byte[] source, string destination, ResolutionContext context) 
            => System.Convert.ToBase64String(source);
    }
}