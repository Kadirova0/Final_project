using Final_project.Data.Enums;
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
        public List<Product> GetProduct();
        public int AddProduct(string name, decimal price, Categories category, int numeral, int id);
        public void DeleteProduct(int id);
        public void UpdateProduct(Product product);


        public List<Sale> GetSale();
        public int AddSale(int id, decimal amount, SaleItem item, DateTime date);
        public void DeleteSale(int id);
    }
}
