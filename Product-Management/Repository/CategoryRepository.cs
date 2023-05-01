using Product_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Product_Management.Repository
{
    internal class CategoryRepository : IRepository<Category>
    {
        private static List<Category> _categories = new List<Category>();
        private uint _id = 0;
        public bool Add(Category entity)
        {
            bool result = false;
            if (entity != null)
            {
                _id++;
                entity.Id = _id;
                _categories.Add(entity);
                result = true;
            }
            return result;
        }

        public bool Delete(uint id)
        {
            bool result = false;
            Category category = _categories.FirstOrDefault(x => x.Id == id);
            if (category != null)
            {
                result= true;
                _categories.Remove(category);
            }
            return result;
        }

        public List<Category> GetAll()
        {
            return _categories.Where(x => x.IsStatus).ToList();
        }

        public Category GetValue(uint id)
        {
            return _categories.FirstOrDefault(x => x.Id == id);
        }

        public bool Update(Category entity)
        {
            bool result = false;
            if (entity != null)
            {
                result= true;
                Category category = _categories.FirstOrDefault(x => x.Id == entity.Id);
                category.Name = String.IsNullOrWhiteSpace(entity.Name) ? category.Name : entity.Name;
            }
            return result;
        }
    }
}
