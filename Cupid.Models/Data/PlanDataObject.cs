using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cupid.Models.Data;

public class PlanDataObject
{
    public int PlanNumber { get; set; }
    public DateTimeOffset? RetiredOn { get; set; } = default!;
    public string PlanName { get; set; } = default!;
}
