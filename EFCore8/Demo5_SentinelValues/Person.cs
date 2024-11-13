namespace EFCore8.Demo5_SentinelValues;

public class Person
{
    public int Id { get; set; }

    public int OverdraftCredit { get; set; } = -1;

    public bool Single { get; set; } = true;
}
