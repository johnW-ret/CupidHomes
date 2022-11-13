namespace Cupid.Models;

public class Salesperson
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public DateTimeOffset DateOfBirth { get; set; }
    public double Commission { get; set; }
    public List<Sale> Sales { get; set; } = default!;
}