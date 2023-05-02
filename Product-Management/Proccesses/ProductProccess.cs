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
        public static void Detail()
        {
            Console.WriteLine("Detail Product.");
            Console.Write("Please Enter Product id.");
            uint id = Convert.ToUInt32(Console.ReadLine());
            try
            {
                Product product = productRepository.GetValue(id);
                Console.WriteLine($"Name: {product.Name}");
                Console.WriteLine($"Description: {product.Description}");
                Console.WriteLine($"CategoryId: {product.CategoryId}");
                Console.WriteLine($"Stock: {product.Stock}");
                Console.WriteLine($"Price: {product.Price}");

            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Product Could Not be Found.");
            }
        }
        public static void Delete()
        {
            Console.WriteLine("Delete Product");
            Console.Write("Please Enter Product id");
            uint id = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine(productRepository.Delete(id) ? "Product Successfuly Deleted." : "Product Could Not be Found.");
        }
        public static void Update()
        {
            Console.WriteLine("Update Product");
            Console.Write("Please Enter Product id.");
            uint id = Convert.ToUInt32(Console.ReadLine());
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Description: ");
            string description = Console.ReadLine();
            Console.Write("CategoryId: ");
            int categoryId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Stock: ");
            int stock = Convert.ToInt32(Console.ReadLine());
            Console.Write("Price: ");
            double price = Convert.ToDouble(Console.ReadLine());
            Product product = new Product(name, description, categoryId, stock, price);
            product.Id = id;
            Console.WriteLine(productRepository.Update(product) ? "Product Successfuly Updated." : "Product Could Not be Found.");
        }
        public static void Deactivate()
        {
            Console.WriteLine("Disable Product.");
            Console.Write("Please Enter Product id.");
            uint id = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine(productRepository.Deactivate(id) ? "Product is disabled." : "Product Could Not be Found.");
        }
        public static void GetAll()
        {
            List<Product> products = productRepository.GetAll();
            if (products != null && products.Count >0)
            {
                foreach (Product product in products)
                {
                    Console.WriteLine($"Name: {product.Name}");
                    Console.WriteLine($"Description: {product.Description}");
                    Console.WriteLine($"CategoryId: {product.CategoryId}");
                    Console.WriteLine($"Stock: {product.Stock}");
                    Console.WriteLine($"Price: {product.Price}");
                }
            }
            else
            {
                Console.WriteLine("No Product.");
            }
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
            Console.WriteLine("Disable Product (5)");
            Console.WriteLine("Product list (6)");
            Console.WriteLine("Up Menu (0)");
            Console.Write("Select Proccess");
            char selected = Convert.ToChar(Console.ReadLine().Substring(0, 1));
            Console.Clear();
            switch (selected)
            {
                case '1':
                    Add();
                    break;
                case '2':
                    Detail();
                    break;
                case '3':
                    Delete();
                    break;
                case '4':
                    Update();
                    break;
                case '5':
                    Deactivate();
                    break;
                case '6':
                    GetAll();
                    break;
                case '0':
                    Program.Main();
                    break;
                default:
                    Console.WriteLine("Incorrect Selection, Please Try Again.");
                    ProductProccess.Menu();
                    break;
            }
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Up Menu (0)");
            Console.Write("Quit (Q)");
            selected = Convert.ToChar(Console.ReadLine().Substring(0, 1));
            switch (selected)
            {
                case '0':
                    Program.Main();
                    break;
                case 'Q':
                    Environment.Exit(0);
                    break;
                case 'q':
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Incorrect Selection, Please Try Again.");
                    UserProccess.Menu();
                    break;
            }
            Console.ReadKey();
        }
    }
}
