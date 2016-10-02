namespace _02.Orders
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using _02.Orders.Models;

    public class DataMapper
    {
        private readonly string categoriesFileName;
        private readonly string productsFileName;
        private readonly string ordersFileName;

        public DataMapper(string categoriesFileName, string productsFileName, string ordersFileName)
        {
            this.categoriesFileName = categoriesFileName;
            this.productsFileName = productsFileName;
            this.ordersFileName = ordersFileName;
        }

        public DataMapper()
            : this(
                  "../../Data/categories.txt",
                  "../../Data/products.txt",
                  "../../Data/orders.txt")
        {
        }

        public IEnumerable<Category> GetAllCategories()
        {
            var category = ReadFileLines(this.categoriesFileName, true);
            return category
                .Select(cat => cat.Split(','))
                .Select(cat => new Category
                {
                    Id = int.Parse(cat[0]),
                    Name = cat[1],
                    Description = cat[2]
                });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var products = ReadFileLines(this.productsFileName, true);
            return products
                .Select(prod => prod.Split(','))
                .Select(prod => new Product
                {
                    Id = int.Parse(prod[0]),
                    Name = prod[1],
                    CategoryId = int.Parse(prod[2]),
                    UnitPrice = decimal.Parse(prod[3]),
                    UnitsInStock = int.Parse(prod[4]),
                });
        }

        public IEnumerable<Order> GetAllOrders()
        {
            var order = ReadFileLines(this.ordersFileName, true)
                .Select(o => o.Split(','))
                .Select(o => new Order
                {
                    Id = int.Parse(o[0]),
                    ProductId = int.Parse(o[1]),
                    Quantity = int.Parse(o[2]),
                    Discount = decimal.Parse(o[3]),
                });

            return order;
        }

        private static IEnumerable<string> ReadFileLines(string filename, bool hasHeader)
        {
            var allLines = new List<string>();
            using (var reader = new StreamReader(filename))
            {
                string currentLine;
                if (hasHeader)
                {
                    reader.ReadLine();
                }

                while ((currentLine = reader.ReadLine()) != null)
                {
                    allLines.Add(currentLine);
                }
            }

            return allLines;
        }
    }
}
