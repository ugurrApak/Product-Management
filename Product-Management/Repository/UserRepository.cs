using Product_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Management.Repository
{
    internal class UserRepository : IRepository<User>
    {
        private static List<User> _users = new List<User>();
        private uint _id = 0;
        public bool Add(User entity)
        {
            bool result = false;
            if (entity != null)
            {
                _id++;
                entity.Id = _id;
                _users.Add(entity);
                result = true;
            }
            return result;
        }

        public bool Delete(uint id)
        {
            bool result = false;
            User user = _users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                _users.Remove(user);
                result = true;
            }
            return result;
        }

        public List<User> GetAll()
        {
            return _users.Where(x => x.IsStatus).ToList();
        }

        public User GetValue(uint id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        public bool Update(User entity)
        {
            bool result = false;
            if (entity != null)
            {
                result = true;
                User user = _users.FirstOrDefault(x => x.Id == entity.Id);
                user.Name = String.IsNullOrWhiteSpace(entity.Name) ? user.Name : entity.Name;
                user.Surname= String.IsNullOrWhiteSpace(entity.Surname) ? user.Surname : entity.Surname;
                user.Email = String.IsNullOrWhiteSpace(entity.Email) ? user.Email : entity.Email;
                user.Password = String.IsNullOrWhiteSpace(entity.Password) ? user.Password : entity.Password;
            }
            return result;
        }
    }
}
