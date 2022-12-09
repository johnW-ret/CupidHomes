using Microsoft.EntityFrameworkCore;
using Cupid.Models;
using Cupid.Models.Data;
using Cupid.Api.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CupidDb>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Cupid")));

builder.Services.AddHttpClient("RandomApi", client => client.BaseAddress = new Uri(builder.Configuration["RandomApi"]));

builder.Services.AddScoped<RandomAddressService>();
builder.Services.AddScoped<RandomUserService>();

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

    return Results.Created($"/customer/{customer.Entity.Id}", customerData);
});

app.MapPost("/customer/random/{count}", async (int count, CupidDb db, RandomUserService randomUserService) =>
{
    var randomUsers = await randomUserService.GetRandomUsers(count);

    var plans = await db.Plan.ToListAsync();

    var getRandomPlans = () => plans.Where(p => Random.Shared.Next(1) == 1);

    foreach (var user in randomUsers)
    {
        var customer = db.Customer.Add(new(
            getRandomPlans().ToList(),
            user.first_name,
            user.last_name,
            string.Empty,
            Random.Shared.Next(1000) * 1000,
            user.email,
            string.Join("", Enumerable.Range(0, 10).Select(x => Random.Shared.Next(0, 10)))));
    }

    await db.SaveChangesAsync();

    return Results.Ok();
});

// plan api
app.MapGet("/plan", async (CupidDb db) => db.Plan
    .ToListAsync()
    .GetAwaiter()
    .GetResult()
    .Select(p => new PlanDataObject(p.Number, p.RetiredOn, p.Name))
    .ToList());

app.MapPost("/plan", async (PlanDataObject planData, CupidDb db) =>
{
    var plan = db.Plan.Add(new(
        planData.PlanNumber,
        planData.PlanName,
        planData.RetiredOn));

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
    .Include(h => h.Address)
    .ToListAsync());

app.MapGet("/house/{id}", async (int id, CupidDb db) =>
    await db.House
    .Include(h => h.Address)
    .FirstOrDefaultAsync(h => h.Id == id)
        is House house
            ? Results.Ok(house)
            : Results.NotFound());

app.MapGet("/house/stats", async (CupidDb db) => await db.House
    .GroupBy(h => h.PlanNumber,
        (PlanNumber, h) => new HouseStat(PlanNumber, h.Count()))
    .ToListAsync());

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

app.MapPost("/house/random/{count}", async (int count, CupidDb db, RandomAddressService randomAddressService) =>
{
    var randomAddresses = await randomAddressService.GetRandomAddresses(count);

    var plans = await db.Plan.ToListAsync();

    var getRandomPlan = () => plans[Random.Shared.Next(plans.Count)];

    foreach (var address in randomAddresses)
    {
        var house = db.House.Add(new(
            getRandomPlan().Number,
            new Address(
                address.street_address,
                address.secondary_address,
                address.city,
                address.state,
                address.zip),
            Random.Shared.Next(300),
            Random.Shared.Next(30),
            string.Empty,
            Random.Shared.Next(1000) * 1000,
            true,
            null));
    }

    await db.SaveChangesAsync();

    return Results.Ok();
});

app.Run();