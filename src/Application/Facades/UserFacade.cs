using System.Threading.Tasks;
using Application.Config;
using Application.DTOs;
using Application.QueryObjects;
using Application.Services;
using AutoMapper;
using Domain.Interfaces;
using Infrastructure.Persistence;

namespace Application.Facades
{
    public class UserFacade
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserService _userService;
        private readonly UserQueryObject _userQueryObject;

        public UserFacade()
        {
            _unitOfWork = new UnitOfWork();
            _mapper = new Mapper(new MapperConfiguration(MappingConfig.ConfigureMapping));
            _userQueryObject = new UserQueryObject(_unitOfWork);
            _userService = new UserService(_unitOfWork, _userQueryObject);
        }

        public async Task<UserPreviewDto> GetByIdAsync(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            return _mapper.Map<UserPreviewDto>(user);
        }
    }
}