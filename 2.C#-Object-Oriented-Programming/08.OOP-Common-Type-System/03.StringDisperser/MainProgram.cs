using System;
namespace _03.StringDisperser
{
    class MainProgram
    {
        public static void Main()
        {
            String_Disperser.StringDisperser stringDisperser = new String_Disperser.StringDisperser("evgeni", "ivan", "siderov");

            foreach (var ch in stringDisperser)
            {
                Console.Write(ch + " ");
            }
            Console.WriteLine();
        }
    }
}
