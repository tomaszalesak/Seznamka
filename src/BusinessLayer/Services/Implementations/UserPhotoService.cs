using BusinessLayer.DataTransferObjects;
using BusinessLayer.DataTransferObjects.Filters;
using BusinessLayer.QueryObjects;
using BusinessLayer.Services.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Query;

namespace BusinessLayer.Services.Implementations;

public class UserPhotoService : CrudQueryServiceBase<UserPhoto, UserPhotoDto, UserPhotoFilterDto>, IUserPhotoService
{
    public UserPhotoService(IRepository<UserPhoto> repository, QueryObjectBase<UserPhoto, UserPhotoDto, UserPhotoFilterDto, IQuery<UserPhoto>> qob) : base(repository, qob)
    {
    }

    public UserPhotoDto GetProfilePhoto(string username)
    {
        var query = QueryObject.ExecuteQuery(new UserPhotoFilterDto
        {
            Username = username
        });
        return query.Items?.FirstOrDefault();
    }
}