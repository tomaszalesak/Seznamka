using Domain.Interfaces.QueryInterfaces;
using Domain.Interfaces.RepositoryInterfaces;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IFriendshipRepository FriendshipRepository { get; }       
        IChatRepository ChatRepository { get; }
        IMessageRepository MessageRepository { get; }
        IPreferencesRepository PreferencesRepository { get; }
        IUserPhotoRepository UserPhotoRepository { get; }
        IUserRepository UserRepository { get; }

        //todo decide which queries are needed
        IFriendshipQuery FriendshipQuery { get; }
        IChatQuery ChatQuery { get; }
        IMessageQuery MessageQuery { get; }
        IPreferencesQuery PreferencesQuery { get; }
        IUserPhotoQuery UserPhotoQuery { get; }
        IUserQuery UserQuery { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
