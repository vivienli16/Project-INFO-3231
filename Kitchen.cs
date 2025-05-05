using System;
using System.Collections.Generic;
using System.Threading;

namespace FoodOrderingSystemConsole
{
    public class Kitchen
    {
        private Inventory inventory;
        public Kitchen(Inventory inv)
        {
            inventory = inv;

        }
        public void PrepareOrder(Order order)
        {
            var totalIngredients = new Dictionary<string, int>();
            int totalTime = 0;

            foreach (var item in order.Items)
            {
                foreach (var ing in item.Ingredients)
                {
                    if (!totalIngredients.ContainsKey(ing.Key))
                        totalIngredients[ing.Key] = 0;

                    totalIngredients[ing.Key] += ing.Value;
                }
                totalTime += item.PrepTimeSeconds;
            }
            if (!inventory.HasIngredients(totalIngredients, out string missing))
            {
                Console.WriteLine($"🚫 Cannot prepare Order #{order.OrderId}. Missing: {missing}");
                return;
            }
            inventory.UseIngredients(totalIngredients);

            Console.WriteLine($"🍳 Preparing Order #{order.OrderId}... Will be ready in {totalTime} seconds.");
            order.ReadyAt = DateTime.Now.AddSeconds(totalTime);

            new Thread(() =>
            {
                Thread.Sleep(totalTime * 1000);
                order.IsPrepared = true;
                Console.WriteLine($"✅ Order #{order.OrderId} is ready!");
            }).Start();
        }
    }           
}
