namespace Demo1_ValueTypes.Models;

public class Customer
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required Address Address { get; set; }
    public List<Order> Orders { get; } = new();
}

public class Order
{
    public int Id { get; set; }
    public required string Contents { get; set; }
    public required Address ShippingAddress { get; set; }
    public required Address BillingAddress { get; set; }
    public Customer Customer { get; set; } = null!;
}
