﻿using Final_project.Data.Enums;
using Final_project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project.Services.Abstract
{
    public interface IShopService
    {
      public List<Product> GetProducts();
        public int AddProduct(string name,decimal price, Categories categories, int quantity);
        public void DeleteProduct(int id);
        public void UpdateProduct(int id, string name, decimal price, Categories category, int quantity);
        List<Product> ShowProductsByPriceRange(decimal minPrice, decimal maxPrice);
        List<Product> SearchProductsByName(string name);

        public List<Sale> GetSales();
        public void AddSale(int productId, int quantity, DateTime date);
        public void DeleteSale(int id);
        List<Sale> ReturnofAnyProductOnSale(int saleId, int productId, int quantity);
        List<Sale> ShowSalesByAmountRange(decimal minAmount, decimal maxAmount);
        List<Sale> ShowSalesByDateRange(DateTime minDate, DateTime maxDate);
        List<Sale> ShowSalesByGivenDate(DateTime date);
        List<Sale> FindSalesByGivenId(int id);
    }
}
