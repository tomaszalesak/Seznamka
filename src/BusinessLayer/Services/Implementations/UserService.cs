using BusinessLayer.DataTransferObjects;
using BusinessLayer.DataTransferObjects.Filters;
using BusinessLayer.QueryObjects;
using BusinessLayer.Services.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Query;

namespace BusinessLayer.Services.Implementations;

public class UserService : CrudQueryServiceBase<User, UserDto, UserFilterDto>, IUserService
{
    public UserService(IRepository<User> repository,
        QueryObjectBase<User, UserDto, UserFilterDto, IQuery<User>> userQueryObject)
        : base(repository, userQueryObject)
    {
    }

    public async Task<string> GetUsernameAsync(int userId)
    {
        var user = await Repository.GetByIdAsync(userId);
        var userDto = Mapper.Map<UserDto>(user);
        return userDto.Username;
    }

    public UserDto GetUserByUsername(string username)
    {
        var user = QueryObject.ExecuteQuery(new UserFilterDto
        {
            Username = username
        });
        return user.Items?.FirstOrDefault();
    }

    public IEnumerable<UserDto> GetAllUsers()
    {
        return QueryObject.ExecuteQuery(new UserFilterDto()).Items.ToList();
    }

    public bool UsernameAlreadyExists(string username)
    {
        var res = QueryObject.ExecuteQuery(new UserFilterDto { Username = username });
        return res.Items.Count >= 1;
    }
}