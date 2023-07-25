using ConsoleTables;
using Final_project.Data.Enums;
using Final_project.Data.Models;
using Final_project.Services.Abstract;
using Final_project.Services.Concrete;
using System;
namespace Final.Services.Concrete
{
    public class MenuService : ShopService
    {
        private static ShopService shopService = new(); 

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
                var products = shopService.GetProducts();
                if (products.Count == 0)
                {
                    Console.WriteLine("There are not product!");
                    return;
                }
                var table = new ConsoleTable("Category");

                foreach (var product in products)
                {
                    table.AddRow(product.Category);
                }
                table.Write();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, error : {ex.Message}");
            }
        }
        public static void MenuShowProductsByPriceRnge()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }


        public static void MenuShowAllSales()
        {
            throw new NotImplementedException();
        }
        public static void MenuAddSale()
        {
            throw new NotImplementedException();
        }
        public static void MenuDeleteSale()
        {
            throw new NotImplementedException();
        }
        public static void MenuReturnofAnyProductonSale()
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
        public static void MenuShowSalesonSpecificDate()
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

