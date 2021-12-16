using BusinessLayer.DataTransferObjects;

namespace BusinessLayer.Services.Interfaces
{
    public interface IBannedUsersService : ICrudQueryServiceBase<BanWithUsersDto>
    {
        public IList<BanWithUsersDto> GetBanned(int id);
    }
}