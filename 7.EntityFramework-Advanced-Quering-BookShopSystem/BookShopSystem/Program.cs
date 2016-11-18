namespace BookShopSystem.Client
{
    using System;
    using System.Collections.Specialized;
    using System.Data;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Reflection;
    using Data;
    using BookShopSytem.Models;
    using EntityFramework.Extensions;

    class Program
    {
        static void Main()
        {
            BookShopContext context = new BookShopContext();

            //Task 1
            //PrintBookTitlesByAgeRestriction(context);

            //Task 2
            //PrintBookTitlesOfGoldenEditionBooksWithLessThan5000Copies(context);

            //Task 3
            //PrintBookTitlesAndPricesWithPriceLowerThan5AndHigherThan40(context);

            //Task 4
            //NotReleasedBooks(context);

            //Task 5
            //BookTitlesByCategory(context);

            //Task 6
            //BookReleasedBeforeDate(context);

            //Task 7
            //AuthorSearch(context);

            //Task 8
            //BookSearch(context);

            //Task 9
            //BookTitleSearch(context);

            //Task 10
            //CountBooks(context);

            //Task 11
            //TotalBookCopies(context);

            //Task 12
            //FindProfit(context);

            //Task 13
            //MostRecentBooks(context);

            //Task 14
            //IncreaseBookCopies(context);

            //Task 15
            //RemoveBooks(context);

            //Task 16
            //StoredProcedure(context);
        }

        private static void StoredProcedure(BookShopContext context)
        {
            Console.Write("Please enter the first and last name of the author separated by a single space: ");
            string[] names = Console.ReadLine().Split(' ');
            SqlParameter firstName = new SqlParameter("@firstName", SqlDbType.VarChar);
            SqlParameter lastName = new SqlParameter("@lastName", SqlDbType.VarChar);
            firstName.Value = names[0];
            lastName.Value = names[1];
            int numberOfBooksWritten = context.Database.SqlQuery<int>("TotalNumberOfBooksByAuthor @firstName, @lastName", firstName, lastName).Single();
            Console.WriteLine($"{firstName.Value} {lastName.Value} has written {numberOfBooksWritten} books");
        }

        private static void RemoveBooks(BookShopContext context)
        {
            Console.Write("Please enter minimal number of copies: ");
            int minNumberOfCopies = int.Parse(Console.ReadLine());

            var booksWithLowerNumberOfCopies = context.Books.Where(book => book.Copies < minNumberOfCopies);
            Console.WriteLine($"{booksWithLowerNumberOfCopies.Count()} books were deleted");
            context.Books.Delete(booksWithLowerNumberOfCopies);
            context.SaveChanges();

        }

        private static void IncreaseBookCopies(BookShopContext context)
        {
            Console.Write($"Please enter release date: ");
            string releaseDateString = Console.ReadLine();
            DateTime releaseDate = DateTime.Parse(releaseDateString);
            Console.Write($"Please enter the number of copies you want to add: ");
            int numberOfCopiesToAdd = int.Parse(Console.ReadLine());
            var count = context.Books.Count(book => book.ReleaseDate > releaseDate);
            Console.WriteLine(count * numberOfCopiesToAdd);
            var books = context.Books.Where(book => book.ReleaseDate > releaseDate);
            //using the EF Extended
            context.Books.Update(books, book => new Book() { Copies = book.Copies + numberOfCopiesToAdd });
            context.SaveChanges();
        }

        private static void MostRecentBooks(BookShopContext context)
        {
            foreach (var count in context.Categories.Select(category => category.Books.Count))
            {
                Console.WriteLine(count);
            }
            var categoryInfoWithTop3ReacentBooks = context.Categories
                .Where(category => category.Books.Count > 35)
                .Select(category => new
                {
                    category.Name,
                    category.Books.Count,
                    RecentBooks = category.Books
                    .OrderByDescending(book => book.ReleaseDate)
                    .ThenBy(book => book.Title)
                    .Select(book => new
                    {
                        book.Title,
                        book.ReleaseDate
                    })
                });
            foreach (var categoryInfoWithTop3ReacentBook in categoryInfoWithTop3ReacentBooks)
            {
                Console.WriteLine($"--{categoryInfoWithTop3ReacentBook.Name}: {categoryInfoWithTop3ReacentBook.Count} books");
                foreach (var recentBook in categoryInfoWithTop3ReacentBook.RecentBooks)
                {
                    Console.WriteLine($"{recentBook.Title} ({recentBook.ReleaseDate.Value.Year})");
                }
            }
        }

        private static void FindProfit(BookShopContext context)
        {
            var profitsByCategories = context.Categories
                .GroupBy(category => new
                {
                    CategoryName = category.Name,
                    CategoryProfit = category.Books.Sum(book => book.Price * book.Copies)
                })
                .OrderByDescending(grouping => grouping.Key.CategoryProfit)
                .ThenBy(grouping => grouping.Key.CategoryName);

            foreach (var profitByCategory in profitsByCategories)
            {
                Console.WriteLine($"{profitByCategory.Key.CategoryName} - ${profitByCategory.Key.CategoryProfit}");
            }
        }

        private static void TotalBookCopies(BookShopContext context)
        {
            var authorInfos = context.Authors.GroupBy(author => new
            {
                FullName = author.FirstName + " " + author.LastName,
                Copies = author.Books.Sum(book => book.Copies)
            }).OrderByDescending(authors => authors.Key.Copies);

            foreach (var authorInfo in authorInfos)
            {
                Console.WriteLine($"{authorInfo.Key.FullName} - {authorInfo.Key.Copies}");
            }
        }

        private static void CountBooks(BookShopContext context)
        {
            Console.Write("Please enter the minimal length of the title: ");
            int minLen = int.Parse(Console.ReadLine());
            var numberOfBooksWithLongerTitleLenght = context.Books.Count(book => book.Title.Length > minLen);
            Console.WriteLine($"The numbe of books with title longer than {minLen} symbols are {numberOfBooksWithLongerTitleLenght}");
        }

        private static void BookTitleSearch(BookShopContext context)
        {
            Console.Write("Please enter the starting string of the last name of the author of the books you want: ");
            string startString = Console.ReadLine();
            var bookInfos = context.Books
                    .Where(book => book.Author.LastName.ToLower().StartsWith(startString.ToLower()))
                    .Select(book => new
                    {
                        book.Title,
                        AuthorFirstName = book.Author.FirstName,
                        AuthorLastName = book.Author.LastName
                    });
            foreach (var bookInfo in bookInfos)
            {
                Console.WriteLine($"{bookInfo.Title} ({bookInfo.AuthorFirstName} {bookInfo.AuthorLastName})");
            }

        }

        private static void BookSearch(BookShopContext context)
        {
            Console.Write("Please enter a string: ");
            string searchedString = Console.ReadLine();
            var bookTitles = context.Books.Where(book => book.Title.Contains(searchedString)).Select(book => book.Title);
            foreach (string bookTitle in bookTitles)
            {
                Console.WriteLine(bookTitle);
            }
        }

        private static void AuthorSearch(BookShopContext context)
        {
            Console.Write("Please enter a string: ");
            string end = Console.ReadLine();

            var authorNames = context.Authors.Where(author => author.FirstName.EndsWith(end)).Select(author => new
            {
                author.FirstName,
                author.LastName
            });

            foreach (var authorName in authorNames)
            {
                Console.WriteLine($"{authorName.FirstName} {authorName.LastName}");
            }
        }

        private static void BookReleasedBeforeDate(BookShopContext context)
        {
            Console.Write("Please enter a date: ");
            DateTime releaseDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);
            var bookTitlesEditionTypesAndPrices = context.Books.Where(book => book.ReleaseDate < releaseDate).Select(book => new
            {
                book.Title,
                book.EditionType,
                book.Price
            });
            foreach (var bookTitlesEditionTypesAndPrice in bookTitlesEditionTypesAndPrices)
            {
                Console.WriteLine($"{bookTitlesEditionTypesAndPrice.Title} - {bookTitlesEditionTypesAndPrice.EditionType} - {bookTitlesEditionTypesAndPrice.Price}");
            }
        }

        private static void BookTitlesByCategory(BookShopContext context)
        {
            var categoryNames = Console.ReadLine().Split(' ').ToList();

            var titles =
                context.Books.Where(book => book.Categories.Count(category => categoryNames.Contains(category.Name)) != 0).Select(book => book.Title);
            foreach (string title in titles)
            {
                Console.WriteLine(title);
            }
        }

        private static void NotReleasedBooks(BookShopContext context)
        {
            Console.Write("Please enter a year: ");
            int years = int.Parse(Console.ReadLine());
            var titles = context.Books.Where(book => book.ReleaseDate.Value.Year != years).Select(book => book.Title);
            foreach (string title in titles)
            {
                Console.WriteLine(title);
            }
        }

        private static void PrintBookTitlesAndPricesWithPriceLowerThan5AndHigherThan40(BookShopContext context)
        {
            var bookTitlesAndPrices = context.Books.Where(book => book.Price < 5 || book.Price > 40).Select(book => new
            {
                book.Title,
                book.Price
            });

            foreach (var bookTitlesAndPrice in bookTitlesAndPrices)
            {
                Console.WriteLine($"{bookTitlesAndPrice.Title} - {bookTitlesAndPrice.Price}");
            }
        }

        private static void PrintBookTitlesOfGoldenEditionBooksWithLessThan5000Copies(BookShopContext context)
        {
            var titles = context.Books.Where(book => book.EditionType == EditionType.Gold && book.Copies < 5000).Select(book => book.Title);
            foreach (string title in titles)
            {
                Console.WriteLine(title);
            }
        }

        private static void PrintBookTitlesByAgeRestriction(BookShopContext context)
        {
            Console.Write("Please enter an age restriction: ");
            string restriction = Console.ReadLine();
            var titles =
                context.Books.Where(
                    book => book.AgeRestriction.ToString().ToLower() == restriction.ToLower())
                    .Select(book => book.Title);
            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }
        }
    }
}



