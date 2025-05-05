public class MenuItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }

   

    public MenuItem(int id, string name, double price)
    {
        Id = id;
        Name = name;
        Price = price;
        Ingredients = new Dictionary<string, int>();
        PrepTimeSeconds = 10; // default prep time
    }
    public Dictionary<string, int> Ingredients { get; set; } = new Dictionary<string, int>();
    public int PrepTimeSeconds { get; set; } = 10;
}
