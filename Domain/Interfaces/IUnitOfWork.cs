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

        //todo add query interfaces if implemented

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
