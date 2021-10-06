using System;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public static class SeznamkaDbContextSeed
    {
        // Specifying IDs is mandatory if seeding db through OnModelCreating method
        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Preferences>().HasData(
                new Preferences
                {
                    Id = 1,
                    MinAge = 19,
                    MaxAge = 25,
                    MinWeight = 50,
                    MaxWeight = 90,
                    MinHeight = 150,
                    MaxHeight = 175,
                    GpsRadius = 5
                });

                modelBuilder.Entity<User>().HasData(new User
                {
                    Id = 1,
                    Name = "Franta",
                    Surname = "Jahoda",
                    Birthdate = DateTime.UtcNow.AddYears(-18),
                    Gender = Gender.Male,
                    Height = 200,
                    Weight = 100,
                    Bio = "I am Franta.",
                    Longitude = 1,
                    Latitude = 2,
                    PreferencesId=1
           },
                new User
                {
                    Id = 2,
                    Name = "Frantiska",
                    Surname = "Jahodova",
                    Birthdate = DateTime.UtcNow.AddYears(-20),
                    Gender = Gender.Female,
                    Height = 150,
                    Weight = 50,
                    Bio = "I am Frantiska.",
                    Longitude = 1,
                    Latitude = 2,
                    PreferencesId = 1,
                },
                new User
                {
                    Id = 3,
                    Name = "Petr",
                    Surname = "Smutný",
                    Birthdate = DateTime.UtcNow.AddYears(-40),
                    Gender = Gender.Other,
                    Height = 185,
                    Weight = 94,
                    Bio = string.Empty,
                    Longitude = 2,
                    Latitude = 3,
                    PreferencesId = 1
                });

            modelBuilder.Entity<Chat>().HasData
            (
                new Chat
                {
                    Name = "Our chat",
                    UserOneId = 1,
                    UserTwoId = 2
                }
            );

            
            modelBuilder.Entity<Message>().HasData
            (
                new Message
                {
                    Id=1,
                    Text = "Hello there",
                    SendTime = DateTime.Now.AddMinutes(-5)
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
}