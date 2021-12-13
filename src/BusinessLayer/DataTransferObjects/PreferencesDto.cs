namespace BusinessLayer.DataTransferObjects;

public class PreferencesDto
{
    public int MinAge { get; set; }

    public int MaxAge { get; set; }

    public int MinWeight { get; set; }

    public int MaxWeight { get; set; }

    public int MinHeight { get; set; }

    public int MaxHeight { get; set; }

    public int GpsRadius { get; set; }
}