using System;
using Infrastructure.Persistence;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main()
        {
            using var dbContext = new SeznamkaDbContext();

            Console.WriteLine("Users");
            foreach (var user in dbContext.Users)
            {
                Console.WriteLine(user.Name);
            }

            Console.WriteLine("Chats");
            foreach (var chat in dbContext.Chats)
            {
                foreach (var message in chat.Messages)
                {
                    Console.WriteLine("    Messages");
                    Console.WriteLine("    " + message.Text);
                }
            }

        }
    }
}