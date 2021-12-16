using Domain.Entities;
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

    public IList<ChatDto> Chats { get; set; }
    
    public IList<BanDto> ReceivedBans { get; set; }
    
    public IList<BanDto> MyBans { get; set; }
    
    public IList<FriendshipDto> Friendships { get; set; }

    public PreferencesDto Preferences { get; set; }

    public IList<UserPhotoDto> Photos { get; set; }
}