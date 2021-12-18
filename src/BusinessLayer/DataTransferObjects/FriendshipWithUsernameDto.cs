namespace BusinessLayer.DataTransferObjects;

public class FriendshipwithUsernameDto
{
    public int UserId { get; set; }

    public UserNamesDto User { get; set; }

    public int FriendId { get; set; }

    public UserNamesDto Friend { get; set; }
}