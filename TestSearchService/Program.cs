using DBSearchLib;
using System;

namespace TestSearchService
{
    class Program
    {
        static void Main(string[] args)
        {
            // This service halps find search results in MSSQL DB by specific input parameters and returns List of results 
            var search = new SerachService();

            //var result = search.Search(new Product { Name = "Al Facker", Price = 50.00m, Weight = 50.00m },
            //     "Product", 
            //     @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ASPNetDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
            //     );

            var result1 = search.Search(new Login { Id = Guid.Parse("A821EE5C-A9C6-445C-A451-0B5D517FE514") },
                "Login", @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ASPNetDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            Console.ReadKey();
        }
    }

    public class Product
    {
        public  Guid? Id { get; set; }
        public string PhotoId { get; set; }   
        public  string Name { get; set; }
        public  string Type { get; set; }
        public  string Color { get; set; }
        public  decimal Weight { get; set; }
        public  decimal Price { get; set; }
        public string Description { get; set; }
    }

    public class Login
    {
        public Guid? Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
