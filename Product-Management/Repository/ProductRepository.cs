using Product_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Product_Management.Repository
{
    internal class ProductRepository : IRepository<Product>
    {
        private static List<Product> _products = new List<Product>();
        private static uint _id = 0;
        public bool Add(Product entity)
        {
            bool result = false;
            if (entity != null)
            {
                _id++;
                entity.Id = _id;
                _products.Add(entity);
                result = true;
            }
            return result;
        }

        public bool Delete(uint id)
        {
            bool result = false;
            Product product = _products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                result= true;
                _products.Remove(product);
            }
            return result;
        }

        public List<Product> GetAll()
        {
            return _products.Where(x => x.IsStatus).ToList();
        }

        public Product GetValue(uint id)
        {
            return _products.FirstOrDefault(x => x.Id == id);
        }

        public bool Update(Product entity)
        {
            bool result = false;
            if (entity != null)
            {
                result= true;
                Product product = _products.FirstOrDefault(x => x.Id == entity.Id);
                product.Name = String.IsNullOrWhiteSpace(entity.Name) ? product.Name : entity.Name;
                product.Price = entity.Price < 0 ? product.Price : entity.Price;
                product.Stock = entity.Stock < 0 ? product.Stock : entity.Stock;
                product.CategoryId = entity.CategoryId <= 0 ? product.CategoryId : entity.CategoryId;
                product.Description = entity.Description;
            }
            return result;
        }
    }
}
