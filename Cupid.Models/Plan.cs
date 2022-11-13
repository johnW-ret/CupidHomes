using System.Text.Json.Serialization;

namespace Cupid.Models;

public class Plan
{
    public int Number { get; set; }
    public string Name { get; set; } = default!;
    public DateTimeOffset? RetiredOn { get; set; }
    [JsonIgnore]
    public ICollection<Customer> Customers { get; set; } = default!;
}