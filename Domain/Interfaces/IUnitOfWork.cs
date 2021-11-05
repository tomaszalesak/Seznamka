using Domain.Interfaces.RepositoryInterfaces;
using System;

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
    }
}
