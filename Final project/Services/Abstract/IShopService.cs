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
      public List<Product> GetProducts();
        public int AddProduct(string name,decimal price, Categories categories, int quantity);
        public void DeleteProduct(int id);

    }
}
