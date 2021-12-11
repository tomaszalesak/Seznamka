using Domain.Enums;

namespace BusinessLayer.DataTransferObjects;

public class UserDto : BaseDto
{
    public string Name { get; set; }
    
    public string Surname { get; set; }
    
    public string Username { get; set; }
    
    public string PasswordHash { get; set; }
    
    public DateTime Birthdate { get; set; }
    
    public Gender Gender { get; set; }
    
    public int Height { get; set; }
    
    public int Weight { get; set; }
    
    public string Bio { get; set; }

    public double Longitude { get; set; }

    public double Latitude { get; set; }

    public virtual IList<ChatDto> Chats { get; set; }

    public virtual IList<UserDto> BlockedUsers { get; set; }

    public virtual IList<FriendshipDto> Friendships { get; set; }

    public PreferencesDto Preferences { get; set; }

    public IList<UserPhotoDto> Photos { get; set; }
}