using System;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Queries;
using Domain.Interfaces.Repositories;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Friendship> FriendshipRepository { get; }       
        IGenericRepository<Chat> ChatRepository { get; }
        IGenericRepository<Message> MessageRepository { get; }
        IGenericRepository<Preferences> PreferencesRepository { get; }
        IGenericRepository<UserPhoto> UserPhotoRepository { get; }
        IGenericRepository<User> UserRepository { get; }
        
        IFriendshipQuery FriendshipQuery { get; }
        IChatQuery ChatQuery { get; }
        IMessageQuery MessageQuery { get; }
        IPreferencesQuery PreferencesQuery { get; }
        IUserPhotoQuery UserPhotoQuery { get; }
        IUserQuery UserQuery { get; }
        
        Task SaveChangesAsync();
    }
}