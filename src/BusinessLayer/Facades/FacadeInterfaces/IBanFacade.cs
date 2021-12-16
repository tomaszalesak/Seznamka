namespace BusinessLayer.Facades.FacadeInterfaces;

public interface IBanFacade : IDisposable
{
    Task Ban(string banningUser, string userToBeBanned);
}