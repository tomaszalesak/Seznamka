using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public sealed class SeznamkaDbContext : DbContext
{
    public SeznamkaDbContext()
    {
        Database.EnsureCreated();
    }

    public SeznamkaDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Friendship> FriendUsers { get; set; }
    public DbSet<Preferences> Preferences { get; set; }
    public DbSet<UserPhoto> UserPhotos { get; set; }
    public DbSet<Chat> Chats { get; set; }
    public DbSet<Message> Messages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(u => u.Preferences)
            .WithOne(p => p.User)
            .HasForeignKey<Preferences>(p => p.UserId);

        modelBuilder.Entity<Friendship>()
            .HasKey(f => new { f.UserId, f.FriendId });

        modelBuilder.Entity<Friendship>()
            .HasOne(f => f.User)
            .WithMany(u => u.Friendships)
            .HasForeignKey(f => f.UserId);

        modelBuilder.Entity<Friendship>()
            .HasOne(f => f.Friend)
            .WithMany()
            .HasForeignKey(f => f.FriendId);

        modelBuilder.Entity<Chat>()
            .HasOne(c => c.MemberOne)
            .WithMany(u => u.Chats)
            .HasForeignKey(c => c.MemberOneId);

        modelBuilder.Entity<Chat>()
            .HasOne(c => c.MemberTwo)
            .WithMany()
            .HasForeignKey(c => c.MemberTwoId);

        modelBuilder.Entity<Message>()
            .HasOne(m => m.Chat)
            .WithMany(c => c.Messages)
            .HasForeignKey(m => m.ChatId);

        modelBuilder.Entity<Message>()
            .HasOne(m => m.Author)
            .WithMany()
            .HasForeignKey(m => m.AuthorId);

        modelBuilder.Entity<UserPhoto>()
            .HasOne(up => up.User)
            .WithMany(u => u.Photos)
            .HasForeignKey(up => up.UserId);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            relationship.DeleteBehavior = DeleteBehavior.Restrict;

        // modelBuilder.Seed();

        base.OnModelCreating(modelBuilder);
    }
}