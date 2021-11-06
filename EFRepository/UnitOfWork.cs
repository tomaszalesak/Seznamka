﻿using Domain.Interfaces;
using Domain.Interfaces.QueryInterfaces;
using Domain.Interfaces.RepositoryInterfaces;
using System;
using System.Threading.Tasks;

namespace EFInfrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SeznamkaDbContext _context;

        //todo reconsider using just generic repo
        public IFriendshipRepository FriendshipRepository { get; }
        public IChatRepository ChatRepository { get; }
        public IMessageRepository MessageRepository { get; }
        public IPreferencesRepository PreferencesRepository { get; }
        public IUserPhotoRepository UserPhotoRepository { get; }
        public IUserRepository UserRepository { get; }

        //todo decide which are needed
        //todo revisit attributes to Include in particular query implementations
        public IFriendshipQuery FriendshipQuery { get; }
        public IChatQuery ChatQuery { get; }
        public IMessageQuery MessageQuery { get; }
        public IPreferencesQuery PreferencesQuery { get; }
        public IUserPhotoQuery UserPhotoQuery { get; }
        public IUserQuery UserQuery { get; }

        //todo add queries to constructor, condense input into objects
        public UnitOfWork
        (
            SeznamkaDbContext context,
            IFriendshipRepository friendshipRepo,
            IChatRepository chatRepo,
            IMessageRepository messageRepo,
            IPreferencesRepository preferencesRepo,
            IUserPhotoRepository userPhotoRepo,
            IUserRepository userRepo
        )
        {
            _context = context;
            FriendshipRepository = friendshipRepo;
            ChatRepository = chatRepo;
            MessageRepository = messageRepo;
            PreferencesRepository = preferencesRepo;
            UserPhotoRepository = userPhotoRepo;
            UserRepository = userRepo;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
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
