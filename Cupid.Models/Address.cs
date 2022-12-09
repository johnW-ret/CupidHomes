namespace Cupid.Models;

public class Address
{
    public int Id { get; set; }
    public string AddressLine1 { get; set; } = default!;
    public string AddressLine2 { get; set; } = default!;
    public string City { get; set; } = default!;
    public string State { get; set; } = default!;
    public string Zip { get; set; } = default!;

    public override string ToString()
    {
        return $"{AddressLine1}, {(!string.IsNullOrEmpty(AddressLine2) ? AddressLine2 + ", " : string.Empty)}{City}, {State}, {Zip}";
    }
}