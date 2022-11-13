namespace Cupid.Models;

public class Sale
{
    public Sale(House? house, Salesperson? salesperson, Customer customer, int budget)
    {
        House = house;
        Salesperson = salesperson;
        Customer = customer ?? throw new ArgumentNullException(nameof(customer));
        Budget = budget;
    }

    public Sale(int id, int? houseId, int? salespersonId, int customerId, DateTimeOffset? closedOn, int budget, int? price)
    {
        Id = id;
        HouseId = houseId;
        SalespersonId = salespersonId;
        CustomerId = customerId;
        ClosedOn = closedOn;
        Budget = budget;
        Price = price;
    }

    public int Id { get; set; }
    public int? HouseId { get; set; }
    public House? House { get; set; }
    public int? SalespersonId { get; set; }
    public Salesperson? Salesperson { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = default!;
    public DateTimeOffset? ClosedOn { get; set; } = default!;
    public ICollection<SaleNote> Notes { get; set; } = default!;
    public int Budget { get; set; } = default!;
    public int? Price { get; set; } = default!;
}