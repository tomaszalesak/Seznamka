namespace BusinessLayer.DataTransferObjects;

public class UsersFoundDto
{
    public IList<UserDto> Users { get; set; }
    public long TotalNumberOfUsers { get; set; }
}