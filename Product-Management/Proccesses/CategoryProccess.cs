using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product_Management.Models;
using Product_Management.Repository;

namespace Product_Management.Proccesses
{
    internal class CategoryProccess
    {
        private static CategoryRepository categoryRepository;
        public CategoryProccess(CategoryRepository repository)
        {
            categoryRepository = repository;
        }
        public static void Add()
        {
            Console.WriteLine("Add Category.");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Category category = new Category(name);
            Console.WriteLine(categoryRepository.Add(category) ? "Category Successfuly Added." : "Category Could Not be Added.");
        }
        public static void Detail()
        {
            Console.WriteLine("Detail Category.");
            Console.Write("Please Enter Category id");
            uint id = Convert.ToUInt32(Console.ReadLine());
            try
            {
                Category category = categoryRepository.GetValue(id);
                Console.Write($"Name: {category.Name}");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Category Could Not be Found.");
                throw;
            }
        }
        public static void Delete()
        {
            Console.WriteLine("Delete Category");
            Console.Write("Please Enter Category id.");
            uint id = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine(categoryRepository.Delete(id) ? "Category Successfuly Deleted." : "Category Could Not be Found.");
        }
        public static void Update()
        {
            Console.WriteLine("Update Category.");
            Console.Write("Please Enter Category id.");
            uint id = Convert.ToUInt32(Console.ReadLine());
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Category category = new Category(name);
            category.Id = id;
            Console.WriteLine(categoryRepository.Update(category) ? "Category Successfuly Updated." : "Category Could Not be Found.");
        }
        public static void GetAll()
        {
            List<Category> categories = categoryRepository.GetAll();
            if(categories != null && categories.Count > 0)
            {
                foreach (Category category in categories)
                {
                    Console.WriteLine($"Name {category.Name}");
                }
            }
            else
            {
                Console.WriteLine("No Category.");
            }
        }
        public static void Menu()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("------ Category Proccess Menu -------");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("----- Select Category Proccess ------");
            Console.WriteLine("Add Category (1)");
            Console.WriteLine("Detail Category (2)");
            Console.WriteLine("Delete Category (3)");
            Console.WriteLine("Update Category (4)");
            Console.WriteLine("Category list (5)");
            Console.WriteLine("Up Menu (0)");
            Console.Write("Select Proccess : ");
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
                    GetAll();
                    break;
                case '0':
                    Program.Main();
                    break;
                default:
                    Console.WriteLine("Incorrect Selection, Please Try Again.");
                    UserProccess.Menu();
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
                default:
                    Console.WriteLine("Incorrect Selection, Please Try Again.");
                    UserProccess.Menu();
                    break;
            }
            Console.ReadKey();
        }
    }
}
