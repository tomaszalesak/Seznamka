﻿namespace BusinessLayer.DataTransferObjects;

public class FriendshipDto
{
    public int UserId { get; set; }
    public int FriendId { get; set; }
    public UserDto User { get; set; }
    public UserDto Friend { get; set; }
}