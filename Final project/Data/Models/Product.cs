using Final_project.Data.Common;
using Final_project.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project.Data.Models
{
    public class Product: BaseEntity
    {
        private static int count = 0;

        public Product(string name, decimal price, Categories category, int quantity) 
        {
            Name = name;
            Price = price;
            Category = category;
            Quantity = quantity;

            Id = count;
            count++;
        }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Categories Category { get; set; }
        public int Quantity { get; set; }
    }
}
