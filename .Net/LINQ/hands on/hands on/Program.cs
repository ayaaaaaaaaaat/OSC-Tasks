using System;
using System.Collections.Generic;
using System.Linq;
public class Order
{
    public int id { get; set; }
    public string customerName { get; set; }
    public bool isDelivered { get; set; }
    public decimal totalAmount { get; set; }
    public List<string> items { get; set; }
}
class Program
{
    static void Main()
    {
        List<Order> orders = new List<Order>
        {
            new Order{id = 1, customerName = "x01", totalAmount = 2500.0m, isDelivered = true, items = new List<string>{"Mouse"}},
            new Order{id = 2, customerName = "x02", totalAmount = 970.0m, isDelivered = false, items = new List<string>{"Monitor"}},
            new Order{id = 3, customerName = "x03", totalAmount = 530.0m, isDelivered = true, items = new List<string>{"Laptop","Case"}},
            new Order{id = 4, customerName = "x04", totalAmount = 700.0m, isDelivered = false, items = new List<string>{"Keyboard"}},
        };
        var undeliveredQuery = orders.Where(o => o.isDelivered == false)
                                      .Select(o => "Order: " + o.id + " for " + o.customerName);
        orders.Add(new Order { id = 5, customerName = "Kareem", totalAmount = 120.0m, isDelivered = false, items = new List<string> {"Webcam"}});
        Console.WriteLine("Undelivered orders:");
        foreach (var s in undeliveredQuery)Console.WriteLine(s);
        var allItems = orders.SelectMany(o => o.items);
        Console.WriteLine("\nAll items across all orders:");
        foreach (var item in allItems)Console.WriteLine(item);
        var sortedOrders = orders.OrderByDescending(o => o.totalAmount);
        var topDelivered = sortedOrders.FirstOrDefault(o => o.isDelivered);
        Console.WriteLine("\nTop delivered order:");
        if (topDelivered != null)
            Console.WriteLine(topDelivered.customerName + "\n with total amount: " + topDelivered.totalAmount);
        else
            Console.WriteLine("No delivered orders found.");
    }
}
