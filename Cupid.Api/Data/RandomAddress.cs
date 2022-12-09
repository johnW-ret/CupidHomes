namespace Cupid.Api.Data;

public class RandomAddress
{
    public string city { get; set; } = default!;
    public string street_address { get; set; } = default!;
    public string secondary_address { get; set; } = default!;
    public string zip { get; set; } = default!;
    public string state { get; set; } = default!;
}