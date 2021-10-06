using System;
using System.Linq;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Persistence;

namespace SampleConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int userId;
            int userId2;
            
            using (var context = new SeznamkaDbContext())
            {
                /*var user = new User
                {
                    Id = 1,
                    Name = "Jan",
                    Surname = "Jahoda",
                    Birthdate = DateTime.UtcNow.AddYears(-18),
                    Gender = Gender.Male,
                    Height = 200,
                    Weight = 100,
                    Bio = "I am Franta.",
                    Longitude = 1,
                    Latitude = 2
                };
                context.Add(user);
                context.SaveChanges();
                
                userId = user.Id;


                var user2 = new User
                {
                    Id = 2,
                    Name = "Jana",
                    Surname = "Jahodova",
                    Birthdate = DateTime.UtcNow.AddYears(-18),
                    Gender = Gender.Female,
                    Height = 200,
                    Weight = 100,
                    Bio = "I am Franta.",
                    Longitude = 1,
                    Latitude = 2
                };
                context.Add(user);
                context.SaveChanges();
                
                userId = user.Id;

                context.SaveChanges();

                var friendship = new Friendship
                {
                    UserId = user.Id,
                    User = user,
                    FriendId = user2.Id,
                    Friend = user2
                };

                context.Add(friendship);
                context.SaveChanges();

                var chat = new Chat
                {
                    Name = "Test chat",
                    UserOneId = user.Id,
                    UserOne = user,
                    UserTwoId = user2.Id,
                    UserTwo = user2,

                };

                context.Add(chat);
                context.SaveChanges();

                var message = new Message
                {
                    Id = 1,
                    Text = "Hello",
                    Chat = chat,
                    SendTime = DateTime.UtcNow.AddMinutes(-5)
                };

                context.Add(message);
                context.SaveChanges();

                var userPhoto = new UserPhoto
                {
                    Id = 1,
                    UserId = user.Id,
                    User = user
                };

                context.Add(userPhoto);
                context.SaveChanges();

                var prefs = new Preferences
                {
                    Id = 1,
                    UserId = user.Id,
                    User = user,
                    MinAge = 19,
                    MaxAge = 25,
                    MinWeight = 50,
                    MaxWeight = 90,
                    MinHeight = 150,
                    MaxHeight = 175,
                    GpsRadius = 5
                };

                context.Add(prefs);
                context.SaveChanges();*/
            }

        }
    }
}
