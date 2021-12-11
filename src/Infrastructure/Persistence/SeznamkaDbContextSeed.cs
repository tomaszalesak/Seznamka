using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public static class SeznamkaDbContextSeed
{
    // Specifying IDs is mandatory if seeding db through OnModelCreating method
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Name = "Franta",
                Surname = "Jahoda",
                Username = "jahoda",
                PasswordHash = "ccccccccccccccc",
                Birthdate = DateTime.UtcNow.AddYears(-18),
                Gender = Gender.Male,
                Height = 200,
                Weight = 100,
                Bio = "I am Franta.",
                Longitude = 1,
                Latitude = 2
            },
            new User
            {
                Id = 2,
                Name = "Frantiska",
                Surname = "Jahodova",
                Username = "wnfowwo",
                PasswordHash = "ccccccccccccccc",
                Birthdate = DateTime.UtcNow.AddYears(-20),
                Gender = Gender.Female,
                Height = 150,
                Weight = 50,
                Bio = "I am Frantiska.",
                Longitude = 1,
                Latitude = 2,
            },
            new User
            {
                Id = 3,
                Name = "Petr",
                Surname = "Smutný",
                Username = "wonowfowrnf",
                PasswordHash = "ccccccccccccccc",
                Birthdate = DateTime.UtcNow.AddYears(-40),
                Gender = Gender.Other,
                Height = 185,
                Weight = 94,
                Bio = string.Empty,
                Longitude = 2,
                Latitude = 3
            });

        modelBuilder.Entity<Preferences>().HasData(
            new Preferences
            {
                Id = 1,
                UserId = 1,
                MinAge = 19,
                MaxAge = 25,
                MinWeight = 50,
                MaxWeight = 90,
                MinHeight = 150,
                MaxHeight = 175,
                GpsRadius = 5
            });

        modelBuilder.Entity<Chat>().HasData
        (
            new Chat
            {
                Id = 1,
                Name = "Our chat 1 a 2",
                MemberOneId = 1,
                MemberTwoId = 2
            }
        );

        modelBuilder.Entity<Message>().HasData
        (
            new Message
            {
                Id = 1,
                Text = "Hello there",
                SendTime = DateTime.Now.AddMinutes(-5),
                AuthorId = 1,
                ChatId = 1
            }
        );

        modelBuilder.Entity<UserPhoto>().HasData(
            new UserPhoto
            {
                Id = 1,
                UserId = 1
            }
        );

        modelBuilder.Entity<Friendship>().HasData(
            new Friendship
            {
                UserId = 1,
                FriendId = 2
            }
        );
    }
}
