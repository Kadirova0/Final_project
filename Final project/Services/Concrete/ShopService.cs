using Final_project.Data.Enums;
using Final_project.Data.Models;
using Final_project.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Final_project.Services.Concrete
{
    public class ShopService : IShopService
    { 
        private List<Product> products;
        private List<Sale> sales;
        private List<SaleItem> saleItems;
       

        public List<Product> GetProducts() //for getting product list
        { 
           return products; 
        } 
        public List<Sale> GetSales() //for getting sale list
        { 
           return sales;
        }
        public List <SaleItem> GetSaleItems()// for getting saleItem list
        { 
           return saleItems;
        }

        public ShopService() 
        {
            products = new List<Product>();
            sales = new List<Sale>();
            saleItems = new List<SaleItem>();
        }

        public int AddProduct(string name, decimal price, Categories category, int quantity)
        {
            //exception checking
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name is null!");
            if (price < 0) throw new Exception("Price is negative!");
            if (quantity < 0) throw new Exception("Quantity is negative");

            var product = new Product(name, price, category, quantity);

            products.Add(product);

            return product.Id;  
        }

        public void DeleteProduct(int id)
        {
            //Product deletion by id
            if (id < 0) throw new Exception("Id is negative!");
            int productIndex = products.FindIndex(x => x.Id == id);
            if (productIndex == -1) throw new Exception("Product not found");
            products.RemoveAt(productIndex);
        }

        public List<Product> ShowProductsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            if (minPrice > maxPrice) throw new Exception("Min price can't be more than Max price!");
            return products.Where(x=> x.Price >= minPrice && x.Price <= maxPrice).ToList();
        }

        public void UpdateProduct(int id, string name, decimal price, Categories category, int quantity)
        {
            //existing product update
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name can't be empty!");
            if (price < 0) throw new Exception("Price can't be negative!");
            if (quantity < 0) throw new Exception("Quantity can't negative!");

            var existingProduct = products.FirstOrDefault(x => x.Id == id);
            if (existingProduct == null) throw new Exception("Product not found!");

            existingProduct.Name = name;
            existingProduct.Price = price;
            existingProduct.Category = category;
            existingProduct.Quantity = quantity;
        }

        public List<Product> SearchProductsByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name can't be empty!");
            return products.Where(x => x.Name.ToLower().Trim() == name.ToLower().Trim()).ToList();
        }

        
        public void AddSale(int productId, int quantity, DateTime date)
        {
            //adding the product from the warehouse to the sale
            List<SaleItem> saleItems = new();
            var product = products.Find(x => x.Id == productId);
            if (product.Quantity < quantity) throw new Exception("not enough product instock:");
            if (quantity < 0) throw new Exception("Quantity can't be negative!");
            if (product != null && product.Quantity >= quantity) 
            {
                var saleItem = new SaleItem(product, quantity);
                saleItems.Add(saleItem);
                var sum = product.Price * quantity;
                product.Quantity -= quantity;
                var sale = new Sale(sum, quantity, DateTime.Today);
                foreach (var item in saleItems)
                {
                   
                }
                sales.Add(sale);

                int option;
               do
               {
                    Console.WriteLine(" Do you want to add another sales item? ");
                    Console.WriteLine("1. Yes");
                    Console.WriteLine("2. No");

                    while (!int.TryParse(Console.ReadLine(), out option))
                    {
                        Console.WriteLine("Invalid option!");
                        Console.WriteLine("Enter option again:");
                    }
                    switch(option)
                    {
                        case 1:
                            Console.WriteLine("Add product ID for sale: ");
                            int salesID = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter quantity:");
                            int secondQuantity = int.Parse(Console.ReadLine());

                            var newProduct = products.Find(x => x.Id == salesID);
                            var secondSum = product.Price * secondQuantity;
                            newProduct.Quantity -= secondQuantity;

                            var newSaleItem = new SaleItem(newProduct, secondQuantity);
                            saleItems.Add(newSaleItem);
                            sale = new Sale(secondSum, secondQuantity, DateTime.Today);
                        foreach(var item in saleItems) 
                        {
                            sale.AddSaleItem(item);
                        }
                            sales.Add(sale);
                        break;

                        case 2:
                            return;
                        default:
                            Console.WriteLine("No such option!");
                        break;
                    }
               } while (option != 2);
            }
         }

        public void DeleteSale(int id)
        {
            if (id < 0) throw new Exception("Id is negative!");
            int saleIndex = sales.FindIndex(x => x.Id == id);
            if (saleIndex == -1) throw new Exception("Sale not found!");
            sales.RemoveAt(saleIndex);
        }

        public List<Sale > ShowSalesByAmountRange(decimal minAmount, decimal maxAmount)
        {
            if (minAmount > maxAmount) throw new Exception("Min price can't be more than Max price!");
            return sales.Where(x => x.Amount >= minAmount && x.Amount <= maxAmount).ToList();
        }

        public List<Sale> ShowSalesByDate(DateTime minDate, DateTime maxDate)
        {
            if (minDate > maxDate) throw new Exception("Min date can't be mor than max date!");
            return sales.Where(x => x.Date >= minDate && x.Date <= maxDate).ToList();
        }

        public List<Sale> ShowSalesOnSpecificDate(DateTime date)
        {
            if (date != DateTime.Today) throw new Exception("No sales on this date!");
            return sales.Where(x =>x.Date == date).ToList();
            //showing the sale on the given date
        }

        public List<Sale> ReturnofAnyProductOnSale(int saleId, int productId, int quantity)
        {
            if (saleId < 0) throw new ArgumentException("Sale ID can't be less than 0.", nameof(saleId));
            if (productId < 0) throw new ArgumentException("Product ID can't be less than 0.", nameof(productId));
            if (quantity <= 0) throw new ArgumentException("Quantity must be greater than 0.", nameof(quantity));

            var sale = sales.FirstOrDefault(s => s.Id == saleId);
            if (sale == null) throw new ArgumentException($"No sale found with ID: {saleId}");

            var saleItem = sale.SaleItem.FirstOrDefault(item => item.Product.Id == productId);
            if (saleItem == null) throw new ArgumentException($"Product with ID: {productId} not found in sale with ID: {saleId}");

            if (quantity > saleItem.Quantity) throw new ArgumentException("Quantity to return exceeds the quantity sold in the sale.");

            var product = products.FirstOrDefault(p => p.Id == productId);
            if (product == null) throw new ArgumentException($"Product with ID: {productId} not found in the list of products.");

            product.Quantity += quantity;
            saleItem.Quantity -= quantity;

            Console.WriteLine($"Product with ID: {productId} returned from sale with ID: {saleId}.");
            return sales;
        }

        public List<Sale> FindSalesByGivenId(int id)
        {
            if (id < 0) throw new Exception("ID can't be less than 0!");

            var salesList = sales.Where(sale => sale.Id == id).ToList();

            if (salesList.Count == 0)
            {
                Console.WriteLine($"No sale found with the given ID: {id}");
            }

            return salesList;
        }
    }  
}
