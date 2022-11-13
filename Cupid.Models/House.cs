namespace Cupid.Models;

public class House
{
    public House(int planNumber, int lotNumber, int blockNumber, string notes, int marketValue, bool isAvailable, DateTimeOffset? closedOn)
    {
        PlanNumber = planNumber;
        LotNumber = lotNumber;
        BlockNumber = blockNumber;
        Notes = notes ?? throw new ArgumentNullException(nameof(notes));
        MarketValue = marketValue;
        IsAvailable = isAvailable;
        ClosedOn = closedOn;
    }

    public House(int id, int planNumber, int lotNumber, int blockNumber, string notes, int marketValue, bool isAvailable, DateTimeOffset? closedOn)
    {
        Id = id;
        PlanNumber = planNumber;
        LotNumber = lotNumber;
        BlockNumber = blockNumber;
        Notes = notes;
        MarketValue = marketValue;
        IsAvailable = isAvailable;
        ClosedOn = closedOn;
    }

    public int Id { get; set; }
    public int PlanNumber { get; set; }
    public Plan Plan { get; set; } = default!;
    public int LotNumber { get; set; }
    public int BlockNumber { get; set; }
    public string Notes { get; set; } = default!;
    public int MarketValue { get; set; }
    public bool IsAvailable { get; set; }
    public DateTimeOffset? ClosedOn { get; set; }
}