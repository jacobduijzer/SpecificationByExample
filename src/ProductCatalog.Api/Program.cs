using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Api;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<JsonOptions>(options =>
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/categories", () => 
    Results.Ok(Enum.GetNames(typeof(Category)).ToList()));

app.MapGet("/categories/{category}", (Category category) => 
    Results.Ok(new BooksByCategoryQuery(category).Handle()));

app.MapPost("/payments", ([FromBody] ShoppingCart shoppingCart) =>
{
    var invoice = new CreateInvoiceFromShoppingBasketCommand(shoppingCart).Handle();
    return Results.Ok(invoice);
});

app.MapGet("/search", ([AsParameters] SearchCriteria criteria) =>
{
    SearchBooksInCategoryQuery query = new(criteria);
    return Results.Ok(query.Handle());
});

app.Run();

public partial class Program { }