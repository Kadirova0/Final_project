using ConsoleTables;
using Final_project.Data.Enums;
using Final_project.Data.Models;
using Final_project.Services.Abstract;
using Final_project.Services.Concrete;
using System;
using System.Collections.ObjectModel;

namespace Final.Services.Concrete
{
    public class MenuService : ShopService
    {
        private static ShopService shopService = new();
        private static IEnumerable<Categories> categories;

        public static void MenuShowAllProducts()
        {
          try
          {
           var products = shopService.GetProducts();
            if (products.Count ==0)
            {
                Console.WriteLine("There are not product!");
                return; 
            }
                var table = new ConsoleTable("Id", "Name", "Price", "Category", "Quantity");
                  
                 foreach (var product in products)
                {
                    table.AddRow(product.Id, product.Name, product.Price, product.Category, product.Quantity);
                }
                table.Write();
          }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, error : {ex.Message}");
            }
        }

        public static void MenuAddProduct()
        {
            try
            {
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter category: ");
            Categories category =(Categories)Enum.Parse(typeof(Categories), Console.ReadLine(), true);  

             Console.WriteLine("Enter quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            int newId = shopService.AddProduct(name, price, category, quantity);
            Console.WriteLine($"Product with ID {newId} was created!");
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Oops, error: {ex.Message}");
            }
        }

        public static void MenuDeleteProduct()
        {
            try 
            { 
            Console.WriteLine("Enter product's ID: ");
            int id = int.Parse(Console.ReadLine()); 

            shopService.DeleteProduct(id);
            Console.WriteLine("Product deleted successfuly!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, error: {ex.Message}");
            }
        }

        public static void MenuShowProductsByCategory()
        {
            try
            {
            Console.WriteLine("Available categories:");
            
            Console.WriteLine("Enter the category name to view products: ");
            string selectedCategory = Console.ReadLine();

            Console.WriteLine("Products in the selected category: ");

            foreach (var product in products)
            {
               if (product.Category == selectedCategory)
                {
                    Console.WriteLine($"Id: {product.Id} | Name: {product.Name} | Price: {product.Price} | Category: {product.Category} | Quantity: {product.Quantity}");
                }
            }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Oops, eror: {ex.Message}");
            }
        }

        public static void MenuShowProductsByPriceRnge()
        {
            try
            {
                Console.WriteLine("Enter minimum price: ");
                decimal minPrice = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Enter maximum price: ");
                decimal maxPrice = decimal.Parse(Console.ReadLine());

                var foundProducts = shopService.ShowProductsByPriceRange(minPrice, maxPrice);
                if (foundProducts.Count == 0)
                {
                    Console.WriteLine("No products found");
                    return;
                }
                foreach (var product in foundProducts)
                {
                    Console.WriteLine($"Id: {product.Id} | Name: {product.Name} | Price: {product.Price} | Category: {product.Category} | Quantity: {product.Quantity}");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Oops, error: {ex.Message}");
            }
        }

        public static void MenuUpdateProduct()
        {
            try 
            {
            Console.WriteLine("Enter ID: ");
            int id =int.Parse(Console.ReadLine());

            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter category: ");
            Categories category = (Categories)Enum.Parse(typeof(Categories), Console.ReadLine(), true);

            Console.WriteLine("Enter quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            shopService.UpdateProduct(id, name, price, category, quantity);
            Console.WriteLine("Update product successfuly!"); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, error: {ex.Message}");
            }
        }

        public static void MenuSearchProductsByName()
        {
           try
           {
            Console.WriteLine("Enter name for search: ");
            string name =Console.ReadLine();

            var foundProducts = shopService.SearchProductsByname(name);

            if (foundProducts.Count == 0)
            {
                Console.WriteLine("No products found: ");
                return;
            }
            foreach (var product in foundProducts)
                {
                    Console.WriteLine($"Id: {product.Id} | Name: {product.Name} | Price: {product.Price} | Category: {product.Category} | Quantity: {product.Quantity}");
                }
           }
            catch(Exception ex)
            {
                Console.WriteLine($"Oops, error: {ex.Message}");
            }
        }


        public static void MenuShowAllSales()
        {
            try
            {
              var sales = shopService.GetSales();
              if (sales.Count == 0)
                {
                  Console.WriteLine("There are not sale!");
                  return;
                }
              var table = new ConsoleTable("Id", "Amount", "SaleItem", "Date");

              foreach (var sale in sales)
                {
                  table.AddRow(sale.Id, sale.Amount, sale.SaleItem, sale.Date);
                }
              table.Write();
            }
            catch (Exception ex)
            {
                 Console.WriteLine($"Oops, error : {ex.Message}");
            }
        }

        public static void MenuAddSale()
        {
            try
            {
              Console.WriteLine("Get Product Id : ");
              int productId = Convert.ToInt32(Console.ReadLine()); 
            

              Console.WriteLine("Enter amount: ");
              int quantity = int.Parse(Console.ReadLine());

              Console.WriteLine("Enter date: ");
              DateTime date  = DateTime.Parse(Console.ReadLine());

              shopService.AddSale(productId,quantity,date);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Oops, error: {ex.Message}");
            }
           
        }
        public static void MenuDeleteSale()
        {
            try
            {
              Console.WriteLine("Enter sale's ID: ");
              int id = int.Parse(Console.ReadLine());

              shopService.DeleteSale(id);
              Console.WriteLine("Sale deleted successfuly!");
            }
            catch (Exception ex)
            {
               Console.WriteLine($"Oops, error: {ex.Message}");
            }
        }

        public static void MenuReturnofAnyProductOnSale()
        {
            throw new NotImplementedException();
        }
        public static void MenuShowSalesByDate()
        {
            throw new NotImplementedException();
        }
        public static void MenuShowSalesByPriceRange()
        {
            throw new NotImplementedException();
        }
        public static void MenuShowSalesOnSpecificDate()
        {
            throw new NotImplementedException();
        }
        public static void MenuShowSalesIssuedUnderId()
        {
            throw new NotImplementedException();
        }
    }
}
        
        
            /*
             
            public static void ShopSales()
            {
            }
            public static void ShopProduct()
            {
            }
            public static void ShopAddSale()
            {
            }
            public static void ShopReturnofAnyProductonSale()
            {
            }
            public static void ShopReturnofGeneralSale()
            {
            }
            public static void ShophowSalesByDate()
            {
            }
            public static void ShopShowSalesonSpecificDate()
            {
            }
            public static void ShopShowSalesByPriceRange()
            {
            }
            public static void ShopShowSalesIssuedUnderId()
            {
            }
            public static void ShopAddProduct()
            {
            }
            public static void ShopUpdateProduct()
            {
            }
            public static void ShopShowProductsByCategory()
            {
            }
            public static void ShopShowProductsByPriceRnge()
            {
            }
            public static void ShopSearchProductsByName()
            {
            }
       */

