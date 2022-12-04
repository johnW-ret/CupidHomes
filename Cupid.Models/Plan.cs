using System.Text.Json.Serialization;

namespace Cupid.Models;

public class Plan
{
    public Plan(int planNumber, string planName, DateTimeOffset? retiredOn)
    {
        Number = planNumber;
        Name = planName;
        RetiredOn = retiredOn;
    }

    public int Number { get; set; }
    public string Name { get; set; } = default!;
    public DateTimeOffset? RetiredOn { get; }
    [JsonIgnore]
    public ICollection<Customer> Customers { get; set; } = default!;
}