namespace EFCore8.Demo2_JsonColumns;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ContactDetails Contact { get; set; }
}

public class ContactDetails
{
    public Address Address { get; set; } = null!;
    public string? Phone { get; set; }
}

public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string Postcode { get; set; }
    public string Country { get; set; }
}
