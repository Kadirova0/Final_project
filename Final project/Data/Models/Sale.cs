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
        public Sale(decimal amount, int quantity, DateTime date)
        {
            Amount = amount;
            SaleItem = new List<SaleItem>();
            Date = date;
            Quantity = quantity;

            Id = count;
            count++;
        }

        public Sale(decimal amount, int quantity, DateTime date, List<SaleItem> saleItem)
        {
            Amount = amount;
            SaleItem = saleItem;
            Date = date;
            Quantity= quantity;

            Id = count;
            count++;
        }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public List<SaleItem> SaleItem { get; set; }
        

        public void AddSaleItem(SaleItem saleItem)
        {
            SaleItem.Add(saleItem);
        }

        public override string ToString()
        {
            return string.Join(", ", SaleItem.Select(item => item.Product));
        }
    } 

}
