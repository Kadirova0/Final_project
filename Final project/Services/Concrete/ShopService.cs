using Final_project.Data.Enums;
using Final_project.Data.Models;
using Final_project.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project.Services.Concrete
{
    public class ShopService : IShopService
    { 
        private List<Product> products;
        private List<Sale> sales;
        private List<SaleItem> saleItems;


        public List<Product> GetProducts() 
        { 
            return products; 
        } 
        public List<Sale> GetSales() 
        { 
          return sales;
        }
        public List <SaleItem> GetSaleItems()
        { 
            return saleItems;
        }

        public ShopService() 
        {
            products = new();
            sales = new();
            saleItems = new();
        }
        public int AddProduct(string name, decimal price, Categories category, int quantity)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name is null!");
            if (price < 0) throw new Exception("Price is negative!");
            if (quantity < 0) throw new Exception("Quantity is negative");

            var product = new Product(name, price, category, quantity);

            products.Add(product);

            return product.Id;  
        }

        public void DeleteProduct(int id)
        {
            if (id < 0) throw new Exception("Id is negative!");
            int productIndex = products.FindIndex(x => x.Id == id);
            if (productIndex == -1) throw new Exception("Product not found");
            products.RemoveAt(productIndex);
        }

        public void UpdateProduct(int id, string name, decimal price, Categories category, int quantity)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name can't be empty!");
            if (price < 0) throw new Exception("Price can't be negative!");
            if (quantity < 0) throw new Exception("Quantity can't negative!");

            var existingProduct = products.FirstOrDefault(x => x.Id == id);
            if (existingProduct != null) throw new Exception("Product not found!");

            existingProduct.Name = name;
            existingProduct.Price = price;
            existingProduct.Category = category;
            existingProduct.Quantity = quantity;

        }
    } 
}
