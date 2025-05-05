//Inventory.cs
using System.Collections.Generic;
public class Inventory
{
    private Dictionary<string, int> stock = new Dictionary<string, int>();

    public Inventory()
    {
        // Starting inventory
        stock["Bun"] = 10;
        stock["Patty"] = 10;
        stock["Lettuce"] = 10;
        stock["Potato"] = 20;
        stock["Soda"] = 15;
        stock["Chicken"] = 10;

    }
    //Check if the inventory has enough ingredients
    public bool HasIngredients(Dictionary<string, int> needed, out string missingItem)
    {
        foreach (var item in needed)
        {
            string name = item.Key;
            int amount = item.Value;

            if (!stock.ContainsKey(name) || stock[name] < amount)
            {
                missingItem = name;
                return false;

            }
        }
        missingItem = null;
        return true;

    }
    //Substract the used ingredients from the inventory
    public void UseIngredients(Dictionary<string, int> used)
    {
        foreach (var item in used)
        {
            string name = item.Key;
            int amount = item.Value;
            if (stock.ContainsKey(name))
            {
                stock[name] -= amount;
            }
        }
    }
}
