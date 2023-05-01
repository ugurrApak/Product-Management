using Product_Management.Models;
using Product_Management.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Management.Proccesses
{
    internal class ProductProccess
    {
        private static ProductRepository productRepository;
        public ProductProccess(ProductRepository repository)
        {
            productRepository = repository;
        }
        public static void Add()
        {
            Console.WriteLine("Add Product.");
            Console.Write("Name:");
            string name = Console.ReadLine();
            Console.Write("Description:");
            string description = Console.ReadLine();
            Console.Write("CategoryId:");
            int categoryId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Stock:");
            int stock = Convert.ToInt32(Console.ReadLine());
            Console.Write("Price:");
            double price = Convert.ToDouble(Console.ReadLine());
            Product product = new Product(name, description, categoryId, stock, price);
            Console.WriteLine(productRepository.Add(product) == true ? "Product Successfuly added." : "Product could not be added.");
        }
        public static void Menu()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("------- Product Proccess Menu -------");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("------ Select Product Proccess ------");
            Console.WriteLine("Add Product (1)");
            Console.WriteLine("Detail Product (2)");
            Console.WriteLine("Delete Product (3)");
            Console.WriteLine("Update Product (4)");
            Console.WriteLine("Product list (5)");
            Console.WriteLine("Up Menu (0)");
            Console.Write("Select Proccess");
            char selected = Convert.ToChar(Console.ReadLine().Substring(0, 1));

            switch (selected)
            {
                case '1':
                    Add();
                    break;
                default:
                    Console.WriteLine("Tanımsız işlem tekrar deneyiniz.");
                    break;
            }
        }
    }
}
