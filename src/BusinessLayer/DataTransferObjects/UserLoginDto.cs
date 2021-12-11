using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.DataTransferObjects;

public record UserLginDto(string UserName, string Password);

public record UserLoginDto
{
    [Required] 
    public string UserName { get; set; }

    [Required] 
    public string Password { get; set; }
}