using Final_project.Helper;
using System;
namespace Final_project
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            int option;

            do
            {
                Console.WriteLine("1. Operation on products: ");
                Console.WriteLine("2. Operation on sales: ");
                Console.WriteLine("0. Log out");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Please, select an option: ");
                Console.WriteLine("---------------------------------");

                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("Please, enter a valid option: ");
                    Console.WriteLine("---------------------------------");
                }
                switch(option)
                {
                    case 1:
                        SubMenu.ProductSubMenu();
                        break; 
                    case 2:
                        SubMenu.SaleSubMenu();
                        break;
                    case 0:
                        Console.WriteLine("Good bye!");
                        break;
                    default:
                        Console.WriteLine("No such option!");
                        break;
                }

            } while (option != 0);
        }
    }
}