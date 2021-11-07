using System.Threading.Tasks;
using Application.QueryObjects;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class UserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserQueryObject userQueryObject;

        public UserService(IUnitOfWork unitOfWork, UserQueryObject queryObject)
        {
            this.unitOfWork = unitOfWork;
            userQueryObject = queryObject;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await unitOfWork.UserRepository.GetByIdAsync(id);
        }
    }
}