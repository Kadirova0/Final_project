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

        public SaleItem(int id, Product product, int numeral)
        {
            Id = id;
            Product = product;
            Numeral = numeral;

            Id = count;
            count++;
        }
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Numeral { get; set; }
    }
}
