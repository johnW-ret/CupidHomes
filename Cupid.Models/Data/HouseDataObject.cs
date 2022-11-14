using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cupid.Models.Data;

public class HouseDataObject
{
    public Address Address { get; set; } = default!;
    public int PlanNumber { get; set; }
    public int LotNumber { get; set; }
    public int BlockNumber { get; set; }
    public string Notes { get; set; } = default!;
    public int MarketValue { get; set; }
    public bool IsAvailable { get; set; }
    public DateTimeOffset? ClosedOn { get; set; } = default!;
}
