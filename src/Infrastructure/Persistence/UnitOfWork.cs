using System;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Queries;
using Domain.Interfaces.Repositories;
using Infrastructure.Persistence.Queries;
using Infrastructure.Persistence.Repositories.Base;

namespace Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SeznamkaDbContext _context;
        
        public IGenericRepository<Friendship> FriendshipRepository { get; }
        public IGenericRepository<Chat> ChatRepository { get; }
        public IGenericRepository<Message> MessageRepository { get; }
        public IGenericRepository<Preferences> PreferencesRepository { get; }
        public IGenericRepository<UserPhoto> UserPhotoRepository { get; }
        public IGenericRepository<User> UserRepository { get; }
        
        public IFriendshipQuery FriendshipQuery { get; }
        public IChatQuery ChatQuery { get; }
        public IMessageQuery MessageQuery { get; }
        public IPreferencesQuery PreferencesQuery { get; }
        public IUserPhotoQuery UserPhotoQuery { get; }
        public IUserQuery UserQuery { get; }
        
        public UnitOfWork(SeznamkaDbContext context)
        {
            _context = context;

            FriendshipRepository = new GenericRepository<Friendship>(context);
            ChatRepository = new GenericRepository<Chat>(context);
            MessageRepository = new GenericRepository<Message>(context);
            PreferencesRepository = new GenericRepository<Preferences>(context);
            UserPhotoRepository = new GenericRepository<UserPhoto>(context);
            UserRepository = new GenericRepository<User>(context);

            FriendshipQuery = new FriendshipQuery(context);
            ChatQuery = new ChatQuery(context);
            MessageQuery = new MessageQuery(context);
            PreferencesQuery = new PreferencesQuery(context);
            UserPhotoQuery = new UserPhotoQuery(context);
            UserQuery = new UserQuery(context);
        }

        public UnitOfWork() : this(new SeznamkaDbContext())
        {

        }
        
        public UnitOfWork
        (
            SeznamkaDbContext context,
            IGenericRepository<Friendship> friendshipRepo,
            IGenericRepository<Chat> chatRepo,
            IGenericRepository<Message> messageRepo,
            IGenericRepository<Preferences> preferencesRepo,
            IGenericRepository<UserPhoto> userPhotoRepo,
            IGenericRepository<User> userRepo,
            IFriendshipQuery friendshipQuery,
            IChatQuery chatQuery,
            IMessageQuery messageQuery,
            IPreferencesQuery preferencesQuery,
            IUserPhotoQuery userPhotoQuery,
            IUserQuery userQuery
        )
        {
            _context = context;

            FriendshipRepository = friendshipRepo;
            ChatRepository = chatRepo;
            MessageRepository = messageRepo;
            PreferencesRepository = preferencesRepo;
            UserPhotoRepository = userPhotoRepo;
            UserRepository = userRepo;

            FriendshipQuery = friendshipQuery;
            ChatQuery = chatQuery;
            MessageQuery = messageQuery;
            PreferencesQuery = preferencesQuery;
            UserPhotoQuery = userPhotoQuery;
            UserQuery = userQuery;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}