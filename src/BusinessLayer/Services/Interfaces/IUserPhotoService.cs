using BusinessLayer.DataTransferObjects;

namespace BusinessLayer.Services.Interfaces
{
    public interface IUserPhotoService : ICrudQueryServiceBase<UserPhotoDto>
    {
        public UserPhotoDto GetProfilePhoto(string username);
    }
}