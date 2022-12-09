using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Cupid.Models.Data;

public class CustomerDataObject
{
    public List<int> PlanNumbers { get; set; } = default!;

    private const string namePattern = "^[a-zA-Z]{2,20}$";
    [RegularExpression(namePattern)]
    public string FirstName { get; set; } = default!;

    [RegularExpression(namePattern)]
    public string LastName { get; set; } = default!;
    public string Notes { get; set; } = default!;
    public int AnnualIncome { get; set; } = default!;

    [EmailAddress]
    public string Email { get; set; } = default!;


    private const string phonePattern = "d{10}$";
    [RegularExpression(phonePattern)]
    public string Phone { get; set; } = default!;
    public string FormattedPhone => Phone is { Length: > 9 }
        ? string.Format("{0}-{1}-{2}",
            Phone[..3],
            Phone[3..6],
            Phone[6..])
        : Phone;
}
