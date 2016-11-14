using System;

namespace _3.HotelDatabase
{
    class Startup
    {
        static void Main()
        {
            HotelContext context = new HotelContext();
            context.Database.Initialize(true);
        }
    }
}
