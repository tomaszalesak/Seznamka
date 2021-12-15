using BusinessLayer.DataTransferObjects;
using BusinessLayer.DataTransferObjects.Filters;
using BusinessLayer.QueryObjects;
using BusinessLayer.Services.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Query;

namespace BusinessLayer.Services.Implementations;

public class UserService : CrudQueryServiceBase<User, UserDto, UsernameUserFilterDto>, IUserService
{
    protected readonly QueryObjectBase<User, UserDto, FindUserFilterDto, IQuery<User>> FindCountQueryObject;
    protected readonly QueryObjectBase<User, UserDto, FindUserFilterDto, IQuery<User>> FindQueryObject;

    public UserService(IRepository<User> repository,
        QueryObjectBase<User, UserDto, UsernameUserFilterDto, IQuery<User>> userQueryObject,
        QueryObjectBase<User, UserDto, FindUserFilterDto, IQuery<User>> findUserQueryObject,
        QueryObjectBase<User, UserDto, FindUserFilterDto, IQuery<User>> findCountQueryObject)
        : base(repository, userQueryObject)
    {
        FindQueryObject = findUserQueryObject;
        FindCountQueryObject = findCountQueryObject;
    }

    public async Task<string> GetUsernameAsync(int userId)
    {
        var user = await Repository.GetByIdAsync(userId);
        var userDto = Mapper.Map<UserDto>(user);
        return userDto.Username;
    }

    public UserDto GetUserByUsername(string username)
    {
        var user = QueryObject.ExecuteQuery(new UsernameUserFilterDto
        {
            Username = username
        });
        return user.Items?.FirstOrDefault();
    }

    public UsersFoundDto GetAllUsers(string userToOmit, UserAgeFilterDto age, UserWeightDto weight,
        UserHeightFilterDto height, int pageSize, int requestedPage)
    {
        var foundUsers = FindQueryObject.ExecuteQuery(new FindUserFilterDto
        {
            OmitUserByUsername = userToOmit,
            PageSize = pageSize,
            RequestedPage = requestedPage,
            Age = age,
            Height = height,
            Weight = weight
        });
        
        var count = FindCountQueryObject.ExecuteQuery(new FindUserFilterDto
        {
            OmitUserByUsername = userToOmit,
            PageSize = pageSize,
            RequestedPage = null,
            Age = age,
            Height = height,
            Weight = weight
        });

        return new UsersFoundDto
        {
            Users = foundUsers.Items.ToList(),
            TotalNumberOfUsers = count.TotalItemsCount
        };
    }

    public bool UsernameAlreadyExists(string username)
    {
        var res = QueryObject.ExecuteQuery(new UsernameUserFilterDto { Username = username });
        return res.Items.Count >= 1;
    }
}