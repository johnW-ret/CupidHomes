namespace Cupid.Models;

public class House
{
    public House(int lotNumber, int blockNumber, string notes, int marketValue, bool isAvailable, DateTimeOffset? closedOn)
    {
        LotNumber = lotNumber;
        BlockNumber = blockNumber;
        Notes = notes ?? throw new ArgumentNullException(nameof(notes));
        MarketValue = marketValue;
        IsAvailable = isAvailable;
        ClosedOn = closedOn;
    }

    public House(int id, int lotNumber, int blockNumber, string notes, int marketValue, bool isAvailable, DateTimeOffset? closedOn)
    {
        Id = id;
        LotNumber = lotNumber;
        BlockNumber = blockNumber;
        Notes = notes;
        MarketValue = marketValue;
        IsAvailable = isAvailable;
        ClosedOn = closedOn;
    }

    public int Id { get; set; }
    public int LotNumber { get; set; }
    public int BlockNumber { get; set; }
    public string Notes { get; set; } = default!;
    public int MarketValue { get; set; }
    public bool IsAvailable { get; set; }
    public DateTimeOffset? ClosedOn { get; set; }
}