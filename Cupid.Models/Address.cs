namespace Cupid.Models;

public class Address
{
    public Address(string addressLine1, string addressLine2, string city, string state, string zip)
    {
        AddressLine1 = addressLine1;
        AddressLine2 = addressLine2;
        City = city;
        State = state;
        Zip = zip;
    }

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