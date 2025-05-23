using System;
using System.Collections.Generic;
using System.Threading;

public class InventoryModule
{
    static string[] foodItems = { "Burger", "Fries", "Soda", "Salad" };
    static int[] quantities = { 5, 10, 8, 3 };

    static void Main()
    {
        Console.WriteLine("Welcome to the Food Ordering System!");

        while (true)
        {
            Console.WriteLine("\nAvailable items:");
            for (int i = 0; i < foodItems.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {foodItems[i]} - Quantity: {quantities[i]}");
            }

            Console.Write("\nEnter the item number to order (0 to exit): ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 0)
            {
                Console.WriteLine("Exiting the system. Goodbye!");
                break;
            }

            if (choice < 1 || choice > foodItems.Length)
            {
                Console.WriteLine("Invalid choice. Try again.");
                continue;
            }

            int index = choice - 1;

            Console.Write($"How many {foodItems[index]}s would you like to order? ");
            int orderAmount = int.Parse(Console.ReadLine());

            CheckAndProcessOrder(index, orderAmount);
        }
    }

    static void CheckAndProcessOrder(int itemIndex, int amount)
    {
        if (quantities[itemIndex] >= amount)
        {
            quantities[itemIndex] -= amount;
            Console.WriteLine($"Order successful! {amount} {foodItems[itemIndex]}(s) ordered.");
        }
        else
        {
            Console.WriteLine($"Sorry! Only {quantities[itemIndex]} {foodItems[itemIndex]}(s) left.");
            Console.Write("Would you like to place an order for more? (yes/no): ");
            string response = Console.ReadLine().ToLower();

            if (response == "yes")
            {
                PlaceRestockOrder(itemIndex, amount);
            }
            else
            {
                Console.WriteLine("Order cancelled.");
            }
        }
    }

    static void PlaceRestockOrder(int itemIndex, int requestedAmount)
    {
        int restockAmount = requestedAmount;
        quantities[itemIndex] += restockAmount;
        Console.WriteLine($"Restocked {restockAmount} {foodItems[itemIndex]}(s). You can now place the order.");
    }
}
