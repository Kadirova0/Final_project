using Final_project.Data.Common;
using Final_project.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project.Data.Models
{
    public class SaleItem: BaseEntity
    {
        private static int count = 0;

        public SaleItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;

            Id = count;
            count++;
        }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
