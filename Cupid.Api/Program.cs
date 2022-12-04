using Microsoft.EntityFrameworkCore;
using Cupid.Models;
using Cupid.Models.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CupidDb>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Cupid")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// customer api
app.MapGet("/customer", async (CupidDb db) => await db.Customer.ToListAsync());

app.MapGet("/customer/{id}", async (int id, CupidDb db) =>
    await db.Customer
    .FirstOrDefaultAsync(c => c.Id == id)
        is Customer customer
            ? Results.Ok(customer)
            : Results.NotFound());

app.MapPost("/customer", async (CustomerDataObject customerData, CupidDb db) =>
{
    var selectedPlans = await db.Plan
        .Where(p => customerData.PlanNumbers.Contains(p.Number))
        .ToListAsync();

    var customer = db.Customer.Add(new(
        selectedPlans,
        customerData.FirstName,
        customerData.LastName,
        customerData.Notes,
        customerData.AnnualIncome,
        customerData.Email,
        customerData.Phone));

    await db.SaveChangesAsync();

    return Results.Created($"/customer/{customer.Entity.Id}", customer.Entity);
});

app.MapPost("/plan", async (PlanDataObject planData, CupidDb db) =>
{
    var plan = db.Plan.Add(new(
        planData.PlanNumber,
        planData.PlanName,
        planData.RetiredOn
        /*new List<Customer>()*/
        ));

    await db.SaveChangesAsync();

    return Results.Created($"/plan/{plan.Entity.Number}", plan.Entity);
});

// sale api
app.MapGet("/sale", async (CupidDb db) => await db.Sale.ToListAsync());

app.MapGet("/sale/{id}", async (int id, CupidDb db) =>
    await db.Sale
    .FirstOrDefaultAsync(s => s.Id == id)
        is Sale sale
            ? Results.Ok(sale)
            : Results.NotFound());

app.MapPost("/sale", async (
    string customerEmail,
    int budget,
    CupidDb db) =>
{
    if (await db.Customer
        .FirstOrDefaultAsync(c => c.Email == customerEmail)
        is not Customer customer)
    {
        return Results.BadRequest("Customer email invalid");
    }

    var sale = db.Sale.Add(new(null, null, customer, budget));
    await db.SaveChangesAsync();

    return Results.Created($"/sale/{sale.Entity.Id}", sale.Entity);
});

// house api
app.MapGet("/house", async (CupidDb db) => await db.House
    .ToListAsync());

app.MapGet("/house/{id}", async (int id, CupidDb db) =>
    await db.House
    .FirstOrDefaultAsync(h => h.Id == id)
        is House house
            ? Results.Ok(house)
            : Results.NotFound());

app.MapPost("/house", async (HouseDataObject houseData, CupidDb db) =>
{
    var house = db.House.Add(new(
        houseData.PlanNumber,
        houseData.Address,
        houseData.LotNumber,
        houseData.BlockNumber,
        houseData.Notes,
        houseData.MarketValue,
        houseData.IsAvailable,
        null));

    await db.SaveChangesAsync();

    return Results.Created($"/house/{house.Entity.Id}", house.Entity);
});

app.Run();