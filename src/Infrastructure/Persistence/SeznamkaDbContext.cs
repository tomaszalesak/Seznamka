using System.Linq;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class SeznamkaDbContext : DbContext
    {
        private const string ConnectionString =
            "Server=(localdb)\\mssqllocaldb;Integrated Security=True;MultipleActiveResultSets=True;Database=Seznamka;Trusted_Connection=True;";

        public DbSet<User> Users { get; set; }
        public DbSet<Friendship> FriendUsers { get; set; }
        public DbSet<Preferences> Preferences { get; set; }
        public DbSet<UserPhoto> UserPhotos { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(ConnectionString)
                .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(a => a.Preferences)
                .WithOne().HasForeignKey<User>(a => a.PreferencesId);

            modelBuilder.Entity<Chat>().HasKey(chat => new { chat.UserOneId, chat.UserTwoId });

            modelBuilder.Entity<Friendship>()
                .HasKey(fs => new { fs.UserId, fs.FriendId });

            modelBuilder.Entity<Friendship>()
              .HasOne(fs => fs.User)
              .WithMany(u => u.Friendships)
              .HasForeignKey(fs => fs.UserId);

            modelBuilder.Entity<Friendship>()
                .HasOne(fs => fs.Friend)
                .WithMany()
                .HasForeignKey(fs => fs.FriendId);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            
            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }
    }
}