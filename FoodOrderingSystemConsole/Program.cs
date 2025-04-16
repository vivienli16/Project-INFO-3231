using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var menu = new List<MenuItem>
        {
            new MenuItem(1, "Cheeseburger", 5.99),
            new MenuItem(2, "Fries", 2.49),
            new MenuItem(3, "Soft Drink", 1.99),
            new MenuItem(4, "Chicken Nuggets", 4.49)
        };

        FrontDesk frontDesk = new FrontDesk();

        while (true)
        {
            Console.WriteLine("\n--- Front Desk Menu ---");
            Console.WriteLine("1. Create Order");
            Console.WriteLine("2. View Orders");
            Console.WriteLine("3. Edit Order");
            Console.WriteLine("4. Delete Order");
            Console.WriteLine("5. Print Order");
            Console.WriteLine("0. Exit");
            Console.Write("Select an option: ");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    frontDesk.CreateOrder(menu);
                    break;
                case "2":
                    frontDesk.ViewOrders();
                    break;
                case "3":
                    Console.Write("Enter Order ID to edit: ");
                    int editId = int.Parse(Console.ReadLine());
                    frontDesk.EditOrder(editId, menu);
                    break;
                case "4":
                    Console.Write("Enter Order ID to delete: ");
                    int deleteId = int.Parse(Console.ReadLine());
                    frontDesk.DeleteOrder(deleteId);
                    break;
                case "5":
                    Console.Write("Enter Order ID to print: ");
                    int printId = int.Parse(Console.ReadLine());
                    frontDesk.PrintOrder(printId);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}
