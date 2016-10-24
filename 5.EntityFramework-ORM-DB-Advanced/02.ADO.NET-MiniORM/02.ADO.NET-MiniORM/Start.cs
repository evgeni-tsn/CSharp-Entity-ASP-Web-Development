using _02.ADO.NET_MiniORM.Entities;
using System;
using System.Collections.Generic;

namespace _02.ADO.NET_MiniORM
{
    class Start
    {
        static void Main()
        {
            string connectionString = new ConnectionStringBuilder("MyWebSiteDatabase").ConnectionString;
            IDbContext context = new EntityManager(connectionString, true);

            #region //Task 11 Fetch Users  
            IEnumerable<User> users = context.FindAll<User>("Age >= 18 AND YEAR(RegistrationDate) > 2010");
            foreach (var user in users)
            {
                Console.WriteLine(user.Username);
            }
            #endregion

        }
    }
}
