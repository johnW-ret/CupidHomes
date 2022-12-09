using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cupid.Models.Data;

public class HouseStat
{
    public HouseStat(int planNumber, int count)
    {
        PlanNumber = planNumber;
        Count = count;
    }

    public int PlanNumber { get; set; }
    public int Count { get; set; }
}
