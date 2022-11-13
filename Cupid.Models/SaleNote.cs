using System.Text.Json.Serialization;

namespace Cupid.Models;

public class SaleNote
{
    public int SaleId { get; set; }
    [JsonIgnore]
    public Sale Sale { get; set; } = default!;
    public DateTimeOffset CreatedOn { get; set; } = default!;
    public string Notes { get; set; } = default!;
}