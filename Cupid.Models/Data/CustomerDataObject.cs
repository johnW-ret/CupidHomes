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
    [Display(Name = "First Name")]
    public string FirstName { get; set; } = default!;

    [RegularExpression(namePattern)]
    [Display(Name = "Last Name")]
    public string LastName { get; set; } = default!;
    public string Notes { get; set; } = default!;

    [Range(0, int.MaxValue)]
    public int AnnualIncome { get; set; } = default!;

    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; } = default!;


    private const string phonePattern = "\\d{10}$";
    [Display(Name = "Phone")]
    [RegularExpression(phonePattern)]
    public string Phone { get; set; } = default!;
    public string FormattedPhone => Phone is { Length: > 9 }
        ? string.Format("{0}-{1}-{2}",
            Phone[..3],
            Phone[3..6],
            Phone[6..])
        : Phone;
}
