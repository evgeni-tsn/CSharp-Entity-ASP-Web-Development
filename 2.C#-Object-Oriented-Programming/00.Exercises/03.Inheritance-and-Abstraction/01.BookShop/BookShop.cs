using System;

namespace _01.BookShop
{

/*
    Our program will work with the following classes:
    •	Book - represents a book that holds title, author and price. Validate that the title and author are not null. The price should never be a negative number. A book should offer information about itself in the format shown in the output below.
    •	GoldenEditionBook - represents a special book holds the same properties as any Book, but its price is always 30% higher.
    */

    class BookShop
    {
        static void Main()
        {
            Book book = new Book("Pod Igoto", "Ivan Vazov", 15.90m );
            Console.WriteLine(book);

            GoldenEditionBook goldenBook = new GoldenEditionBook("Tutun","Dimitar Dimov", 22.90m);
            Console.WriteLine(goldenBook);
        }
    }
}