using Final.Services.Concrete;
using Final_project.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project.Helper
{
    public class SubMenu: MenuService
    {
        public static void ProductSubMenu() 
        {
            Console.Clear();

            int option;

            do
            {
                Console.WriteLine("1. Show all products");
                Console.WriteLine("2. Add  product");
                Console.WriteLine("3. Delete product");
                Console.WriteLine("4. Show  products by category");
                Console.WriteLine("5. Show  products by price range");
                Console.WriteLine("6. Update product ");
                Console.WriteLine("7. Search products by name");
                Console.WriteLine("0. Go back");

                Console.WriteLine("---------------------------------");
                Console.WriteLine("Please, select an option: ");
                Console.WriteLine("---------------------------------");

                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Please, enter a valid option:");
                    Console.WriteLine("-----------------------------");
                }
                switch (option)
                {
                    case 1:
                        MenuService.MenuShowAllProducts();
                        break;
                    case 2:
                        MenuService.MenuAddProduct();
                        break;
                    case 3:
                        MenuService.MenuDeleteProduct();
                        break;
                    case 4:
                        MenuService.MenuShowProductsByCategory();
                        break;
                    case 5:
                        MenuService.MenuShowProductsByPriceRnge();
                        break;
                    case 6:
                        MenuService.MenuUpdateProduct();
                        break;
                    case 7:
                        MenuService.MenuSearchProductsByName();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("No such option!");
                        break;
                }

            } while (option != 0);
        }
        public static void SaleSubMenu()
        {
            Console.Clear();

            int option;

            do
            {
                Console.WriteLine("1. Show all sales");
                Console.WriteLine("2. Add sale");
                Console.WriteLine("3. Delete sale");
                Console.WriteLine("4. Return of any product on sale");
                Console.WriteLine("5. Show sales by date");
                Console.WriteLine("6. Show sales by price range");
                Console.WriteLine("7. Shows sales on a specific date");
                Console.WriteLine("8. Show sales issued under ID");
                Console.WriteLine("0. Go back");

                Console.WriteLine("----------------------------------");
                Console.WriteLine("Enter an option please: ");
                Console.WriteLine("------------------------------*---");

                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("Please, enter a valid option: ");
                    Console.WriteLine("------------------------------");
                }
                switch (option)
                {
                    case 1:
                        MenuService.MenuShowAllSales();
                        break;
                    case 2:
                        MenuService.MenuAddSale();
                        break;
                    case 3:
                        MenuService.MenuDeleteSale();
                        break;
                    case 4:
                        MenuService.MenuReturnofAnyProductonSale();
                        break;
                    case 5:
                        MenuService.MenuShowSalesByDate();
                        break;
                    case 6:
                        MenuService.MenuShowSalesByPriceRange();
                        break;
                    case 7:
                        MenuService.MenuShowSalesonSpecificDate();
                        break;
                    case 8:
                        MenuService.MenuShowSalesIssuedUnderId();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("No such option!");
                        break;
                }

            } while (option != 0);
        }
    }
}