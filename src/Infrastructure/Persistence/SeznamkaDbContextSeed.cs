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
                    Latitude = 2
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
                    Latitude = 2
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
        }
    }
}