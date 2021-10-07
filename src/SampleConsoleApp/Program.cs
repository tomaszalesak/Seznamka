using System;
using Infrastructure.Persistence;

namespace SampleConsoleApp
{
    class Program
    {
        static void Main()
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
                foreach (var message in dbContext.Messages)
                {
                    Console.WriteLine("    Messages");
                    Console.WriteLine("    " + message.Text);
                }
            }

        }
    }
}
