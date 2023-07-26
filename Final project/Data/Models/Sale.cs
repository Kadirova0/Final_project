using Final_project.Data.Common;
using Final_project.Data.Enums;
using Final_project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project.Data.Models
{
    public class Sale : BaseEntity
    {
        private static int count = 0;

        public Sale(decimal amount, SaleItem saleItem, DateTime date)
        {
            Amount = amount;
            SaleItem = saleItem;
            Date = date;

            Id = count;
            count++;
        }
        public decimal Amount { get; set; }
        public SaleItem SaleItem { get; set; }
        public DateTime Date { get; set; }
    } 
}
