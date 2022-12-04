using System.Text.Json.Serialization;

namespace Cupid.Models;

public class Plan
{
    public Plan(int number, string name, DateTimeOffset? retiredOn)
    {
        Number = number;
        Name = name ?? throw new ArgumentNullException(nameof(name));
        RetiredOn = retiredOn;
    }

    public int Number { get; set; }
    public string Name { get; set; } = default!;
    public DateTimeOffset? RetiredOn { get; }
    [JsonIgnore]
    public ICollection<Customer> Customers { get; set; } = default!;
}