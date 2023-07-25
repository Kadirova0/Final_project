﻿using Final_project.Data.Common;
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

        public Sale(int id, decimal amount, SaleItem item, DateTime date)
        {
            Id = id;
            Amount = amount;
            Date = date;

            Id = count;
            count++;
        }
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public SaleItem Item { get; set; }
        public DateTime Date { get; set; }
    } 
}