using DBSearchLib;
using System;

namespace TestSearchService
{
    class Program
    {
        static void Main(string[] args)
        {
            var search = new SerachService();

            search.Search(new Product{ Name = "string", Price = 1 }, 
                "Product", @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ASPNetDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

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
        public int MyPropertyTestInt { get; set; }
    }
}
