using System.Text.Json.Serialization;

namespace Cupid.Models;

public class Customer
{
    public Customer(string firstName, string lastName, string notes, int annualIncome, string email, string phone)
    {
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        Notes = notes ?? throw new ArgumentNullException(nameof(notes));
        AnnualIncome = annualIncome;
        Email = email ?? throw new ArgumentNullException(nameof(email));
        Phone = phone ?? throw new ArgumentNullException(nameof(phone));
    }

    public Customer(List<Plan> plans, string firstName, string lastName, string notes, int annualIncome, string email, string phone)
    {
        Plans = plans ?? throw new ArgumentNullException(nameof(plans));
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        Notes = notes ?? throw new ArgumentNullException(nameof(notes));
        AnnualIncome = annualIncome;
        Email = email ?? throw new ArgumentNullException(nameof(email));
        Phone = phone ?? throw new ArgumentNullException(nameof(phone));
    }

    public int Id { get; set; }
    public ICollection<Plan> Plans { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Notes { get; set; } = default!;
    public int AnnualIncome { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Phone { get; set; } = default!;
    [JsonIgnore]
    public List<Sale> Sales { get; set; } = default!;
}