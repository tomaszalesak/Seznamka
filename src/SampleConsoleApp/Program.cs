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
                var user = new User
                {
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
            }

            using (var context = new SeznamkaDbContext())
            {
                var user = context.Users.Single(user => user.Id == userId);
                foreach (var animal in user.Friendships)
                {
                    Console.WriteLine(animal.Name);
                }

                var ripAnimal = context.Animal.First(a => a.Id == animal2Id);
                context.Remove(ripAnimal);
                context.SaveChanges();

                foreach (var animal in enclosure.Animals)
                {
                    Console.WriteLine(animal.Name);
                }
            }
        }
    }
}
