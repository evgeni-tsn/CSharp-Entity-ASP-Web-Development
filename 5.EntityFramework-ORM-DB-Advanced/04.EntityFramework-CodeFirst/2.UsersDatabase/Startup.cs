using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using _2.UsersDatabase.Models;

namespace _2.UsersDatabase
{
    class Startup
    {
        static void Main()
        {
            UsersContext context = new UsersContext();
            context.Database.Initialize(true);

//            // 11.	Get Users by Email Provider
//            Console.WriteLine("Please enter email provider: ");
//            string emailProvider = Console.ReadLine();
//            GetUsersByEmailProvider(context, emailProvider);

//            // 12.	Count Users with Bigger Pictures
//             Console.WriteLine("Please enter number of pixels: ");
//             int numberOfPixels = int.Parse(Console.ReadLine());
//             int countOfBigPictures = GetCountOfBiggerPictures(context, numberOfPixels);
//             Console.WriteLine($"{countOfBigPictures} users have profile pictures wider than {numberOfPixels} pixels");

//            // 13.	Remove Inactive Users                
//            Console.WriteLine("Please enter a date: ");
//            string enteredDateString = Console.ReadLine();
//            DateTime enteredDate = DateTime.Parse(enteredDateString); 
//            RemoveInactiveUsers(context, enteredDate);
        }

        private static int GetCountOfBiggerPictures(UsersContext context, int numberOfPixels)
        {
            IEnumerable<User> userWithPictures = context.Users.Where(user => user.ProfilePicture != null);
            int count = 0;

            foreach (User userWithPicture in userWithPictures)
            {
                if (userWithPicture.ProfilePicture[0] > numberOfPixels)
                {
                    count++;
                }
            }

            return count;
        }

        private static void RemoveInactiveUsers(UsersContext context, DateTime logDate)
        {
            List<User> users = context.Users.Where(user => user.LastTimeLoggedIn < logDate && !user.isDeleted).ToList();
            foreach (User user in users)
            {
                user.isDeleted = true;
            }
            if (users.Count == 0)
            {
                Console.WriteLine("No users have been deleted");
            }
            else
            {
                Console.WriteLine($"{users.Count} user has been deleted");
            }

            context.SaveChanges();
        }

        private static void GetUsersByEmailProvider(UsersContext context, string emailProvider)
        {
            IEnumerable<User> wantedUsers = context.Users.Where(user => user.Email.EndsWith(emailProvider));
            foreach (User wantedUser in wantedUsers)
            {
                Console.WriteLine($"{wantedUser.Username} {wantedUser.Password} - {wantedUser.Age}");
            }
        }
    }
}
