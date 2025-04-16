using System;
using System.Collections.Generic;

public class FrontDesk
{
    private List<Order> orders = new List<Order>();
    private int nextOrderId = 1;

    public void CreateOrder(List<MenuItem> menu)
    {
        Order newOrder = new Order();
        newOrder.OrderId = nextOrderId++;

        Console.WriteLine("Creating new order. Type -1 to finish.");
        while (true)
        {
            Console.WriteLine("\nMenu:");
            foreach (var item in menu)
                Console.WriteLine($"{item.Id}. {item.Name} - ${item.Price}");

            Console.Write("Enter item ID to add: ");
            if (!int.TryParse(Console.ReadLine(), out int choice)) continue;
            if (choice == -1) break;

            var selected = menu.Find(m => m.Id == choice);
            if (selected != null)
            {
                newOrder.Items.Add(selected);
                Console.WriteLine($"{selected.Name} added.");
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        if (newOrder.Items.Count > 0)
        {
            orders.Add(newOrder);
            Console.WriteLine($"✅ Order #{newOrder.OrderId} created!");
        }
        else
        {
            Console.WriteLine("❌ Empty order was not saved.");
        }
    }

    public void ViewOrders()
    {
        Console.WriteLine("\n--- Current Orders ---");
        foreach (var order in orders)
        {
            Console.WriteLine($"Order #{order.OrderId}:");
            foreach (var item in order.Items)
            {
                Console.WriteLine($"  - {item.Name} (${item.Price})");
            }
            Console.WriteLine($"  ➤ Status: {(order.IsPrepared ? "Ready" : "Preparing")}\n");
        }
    }

    public void EditOrder(int orderId, List<MenuItem> menu)
    {
        var order = orders.Find(o => o.OrderId == orderId);
        if (order == null)
        {
            Console.WriteLine("Order not found.");
            return;
        }

        Console.WriteLine("Editing order. Type -1 to finish.");
        order.Items.Clear();

        while (true)
        {
            Console.WriteLine("\nMenu:");
            foreach (var item in menu)
                Console.WriteLine($"{item.Id}. {item.Name} - ${item.Price}");

            Console.Write("Enter item ID to add: ");
            if (!int.TryParse(Console.ReadLine(), out int choice)) continue;
            if (choice == -1) break;

            var selected = menu.Find(m => m.Id == choice);
            if (selected != null)
            {
                order.Items.Add(selected);
                Console.WriteLine($"{selected.Name} added.");
            }
        }

        Console.WriteLine("Order updated.");
    }

    public void DeleteOrder(int orderId)
    {
        var order = orders.Find(o => o.OrderId == orderId);
        if (order != null)
        {
            orders.Remove(order);
            Console.WriteLine($"Order #{orderId} deleted.");
        }
        else
        {
            Console.WriteLine("Order not found.");
        }
    }

    public void PrintOrder(int orderId)
    {
        var order = orders.Find(o => o.OrderId == orderId);
        if (order == null)
        {
            Console.WriteLine("Order not found.");
            return;
        }

        Console.WriteLine($"\n🧾 Order #{order.OrderId}");
        double total = 0;
        foreach (var item in order.Items)
        {
            Console.WriteLine($"- {item.Name} (${item.Price})");
            total += item.Price;
        }
        Console.WriteLine($"Total: ${total}\n");
    }
}
