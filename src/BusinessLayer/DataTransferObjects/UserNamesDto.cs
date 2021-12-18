namespace BusinessLayer.DataTransferObjects;

public class UserNamesDto : BaseDto
{
    public string Name { get; set; }
    
    public string Surname { get; set; }
    
    public string Username { get; set; }
    public IList<UserPhotoDto> Photos { get; set; }
}