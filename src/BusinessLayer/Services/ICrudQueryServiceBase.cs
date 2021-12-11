namespace BusinessLayer.Services;

public interface ICrudQueryServiceBase<TDto>
{
    public Task<TDto> GetAsync(params object[] keyValues);
    public Task CreateAsync(TDto entityDto);
    public void Update(TDto entityDto);
    public Task DeleteAsync(params object[] keyValues);
}