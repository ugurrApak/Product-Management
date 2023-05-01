using Product_Management.Models;
using Product_Management.Repository;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Product_Management.Proccesses
{
    internal class UserProccess
    {
        private static UserRepository userRepository;
        public UserProccess(UserRepository repository)
        {
            userRepository = repository;
        }
        public static void Add()
        {
            Console.WriteLine("Add User.");
            Console.Write("Name:");
            string name = Console.ReadLine();
            Console.Write("Surname:");
            string surname = Console.ReadLine();
            Console.Write("Email:");
            string email = Console.ReadLine();
            Console.Write("Password:");
            string password = Console.ReadLine();
            User user = new User(name, surname, email, password);
            Console.WriteLine(userRepository.Add(user) ? "User Successfuly Added." : "User Could Not be Added.");
        }
        public static void Detail()
        {
            Console.WriteLine("Detail User.");
            Console.Write("Please Enter User Id.");
            uint id = Convert.ToUInt32(Console.ReadLine());
            try
            {
                User user = userRepository.GetValue(id);
                Console.Write($"Name: {user.Name}");
                Console.Write($"Surname: {user.Surname}");
                Console.Write($"Email: {user.Email}");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("User Could Not be Found.");
                throw;
            }
        }
        public static void Delete()
        {
            Console.WriteLine("Delete User.");
            Console.Write("Please Enter User Id.");
            uint id = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine(userRepository.Delete(id) ? "User Successfuly Deleted." : "User Could Not Be Found.");
        }
        public static void Update()
        {
            Console.WriteLine("Update User.");
            Console.Write("Please Enter User Id.");
            uint id = Convert.ToUInt32(Console.ReadLine());
            Console.Write("Name:");
            string name = Console.ReadLine();
            Console.Write("Surname:");
            string surname = Console.ReadLine();
            Console.Write("Email:");
            string email = Console.ReadLine();
            Console.Write("Password:");
            string password = Console.ReadLine();
            User user = new User(name,surname,email,password);
            user.Id= id;
            Console.WriteLine(userRepository.Update(user) ? "User Successfuly Updated" : "User Could Not Be Found");
        }
        public static void GetAll()
        {
            List<User> users = userRepository.GetAll();
            if(users != null && users.Count > 0)
            {
                foreach (User user in users)
                {
                    Console.WriteLine($"Name: {user.Name}");
                    Console.WriteLine($"Surname: {user.Surname}");
                    Console.WriteLine($"Email: {user.Email}");
                }
            }
            else
            {
                Console.WriteLine("No users");
            }

        }
        public static void Menu()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("-------- User Proccess Menu ---------");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("------- Select User Proccess --------");
            Console.WriteLine("Add User (1)");
            Console.WriteLine("Detail User (2)");
            Console.WriteLine("Delete User (3)");
            Console.WriteLine("Update User (4)");
            Console.WriteLine("User list (5)");
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
