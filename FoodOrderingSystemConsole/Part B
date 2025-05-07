using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public class InventoryItem
{
    public string Name { get; set; }
    public int Quantity { get; set; }

    public InventoryItem(string name, int quantity)
    {
        Name = name;
        Quantity = quantity;
    }
}

public class Inventory
{
    private List<InventoryItem> stock = new List<InventoryItem>();

    public Inventory()
    {
        stock.Add(new InventoryItem("Beef Patty", 10));
        stock.Add(new InventoryItem("Buns", 10));
        stock.Add(new InventoryItem("Cheese", 10));
        stock.Add(new InventoryItem("Fries", 15));
        stock.Add(new InventoryItem("Soda", 20));
        stock.Add(new InventoryItem("Chicken", 10));
    }

    public bool CheckAndUseIngredients(List<MenuItem> items, out List<string> missingIngredients)
    {
        Dictionary<string, int> required = new Dictionary<string, int>();
        missingIngredients = new List<string>();

        foreach (var item in items)
        {
            // Define basic recipe logic (simple example)
            switch (item.Name)
            {
                case "Cheeseburger":
                    AddToDict(required, "Beef Patty", 1);
                    AddToDict(required, "Buns", 1);
                    AddToDict(required, "Cheese", 1);
                    break;
                case "Fries":
                    AddToDict(required, "Fries", 1);
                    break;
                case "Soft Drink":
                    AddToDict(required, "Soda", 1);
                    break;
                case "Chicken Nuggets":
                    AddToDict(required, "Chicken", 1);
                    break;
            }
        }

        foreach (var req in required)
        {
            var inv = stock.Find(i => i.Name == req.Key);
            if (inv == null || inv.Quantity < req.Value)
            {
                missingIngredients.Add(req.Key);
            }
        }

        if (missingIngredients.Any())
            return false;

        // Deduct ingredients
        foreach (var req in required)
        {
            var inv = stock.Find(i => i.Name == req.Key);
            if (inv != null)
                inv.Quantity -= req.Value;
        }

        return true;
    }

    private void AddToDict(Dictionary<string, int> dict, string key, int amount)
    {
        if (dict.ContainsKey(key))
            dict[key] += amount;
        else
            dict[key] = amount;
    }

    public void ShowInventory()
    {
        Console.WriteLine("\n📦 Inventory:");
        foreach (var item in stock)
            Console.WriteLine($"- {item.Name}: {item.Quantity}");
    }
}

public class Kitchen
{
    private Inventory inventory;

    public Kitchen(Inventory inventory)
    {
        this.inventory = inventory;
    }

    public void PrepareOrder(Order order)
    {
        Console.WriteLine($"\n🍳 Preparing Order #{order.OrderId}...");

        if (!inventory.CheckAndUseIngredients(order.Items, out List<string> missing))
        {
            Console.WriteLine("❌ Cannot prepare order. Missing ingredients:");
            foreach (var item in missing)
                Console.WriteLine($"  - {item}");
            Console.WriteLine("📢 Notification sent to front desk.");
            return;
        }

        // Simulate cooking time
        int prepTime = new Random().Next(2, 5); // minutes
        Console.WriteLine($"⏱️ Estimated ready time: {prepTime} minutes.");
        Console.WriteLine("🔥 Cooking...");

        Thread.Sleep(1000); // Simulate short wait (in real system, would be timed callback)

        order.IsPrepared = true;
        Console.WriteLine($"✅ Order #{order.OrderId} is READY!");
        Console.WriteLine("📢 Notification sent to front desk.");
    }
}
