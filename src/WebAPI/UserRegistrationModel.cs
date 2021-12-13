using BusinessLayer.DataTransferObjects;
using Domain.Enums;

namespace WebAPI;

public class UserRegistrationModel
{
    public string Name { get; set; }
    
    public string Surname { get; set; }
    
    public string Username { get; set; }
    
    public string Password { get; set; }
    
    public DateTime Birthdate { get; set; }
    
    public Gender Gender { get; set; }
    
    public int Height { get; set; }
    
    public int Weight { get; set; }
    
    public string Bio { get; set; }

    public double Longitude { get; set; }

    public double Latitude { get; set; }
    
    public PreferencesDto PreferencesDto { get; set; }
    
    public IFormFile Photo { get; set; }
}