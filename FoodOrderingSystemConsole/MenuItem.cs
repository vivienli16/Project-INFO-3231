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
    }
}
