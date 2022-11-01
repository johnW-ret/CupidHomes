namespace Cupid.Models;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string? Notes { get; set; }
    public int AnnualIncome { get; set; }
    public string? Email { get; set; }
    public Phone? Phone { get; set; }
    public DateTimeOffset? RetiredOn { get; set; }
}