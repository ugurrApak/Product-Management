using Product_Management.AbstractModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Product_Management.Models
{
    internal class Product:CommonProp
    {
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public Product(string name, string description, int categoryId, int stock, double price)
        {
            Name = name;
            Description = description;
            CategoryId = categoryId;
            Stock = stock;
            Price = price;
        }
    }
}
