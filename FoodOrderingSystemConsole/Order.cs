using System.Collections.Generic;

public class Order
{
    public int OrderId { get; set; }
    public List<MenuItem> Items { get; set; } = new List<MenuItem>();
    public bool IsPrepared { get; set; } = false;
}
