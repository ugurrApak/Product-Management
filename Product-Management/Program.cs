﻿using Product_Management.Proccesses;
using Product_Management.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Management
{
    internal class Program
    {
        public static void Main(string[] args = null)
        {
            UserRepository userRepository = new UserRepository();
            UserProccess userProccess = new UserProccess(userRepository);
            ProductRepository productRepository = new ProductRepository();
            ProductProccess productProccess = new ProductProccess(productRepository);
            CategoryRepository categoryRepository = new CategoryRepository();
            CategoryProccess categoryProccess = new CategoryProccess(categoryRepository);
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("---------- Proccess Menu ------------");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("-------Select Product ---------------");
            Console.WriteLine("Product Proccess (1)");
            Console.WriteLine("Category Proccess (2)");
            Console.WriteLine("User Proccess (3)");
            Console.WriteLine("Exit Program (0)");
            Console.Write("Select Proccess : ");
            char selected = Convert.ToChar(Console.ReadLine().Substring(0, 1));
            Console.Clear();
            switch (selected)
            {
                case '1':
                    ProductProccess.Menu();
                    break;
                case '2':
                    CategoryProccess.Menu();
                    break;
                case '3':
                    UserProccess.Menu();
                    break;
                case '0':
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Incorrect Selection, Please Try Again");
                    Program.Main();
                    break;
            }
        }
    }
}
