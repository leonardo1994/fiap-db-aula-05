using Microsoft.AspNetCore.Mvc;
using ProductService.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AdventureFiapContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/products/{id}", async (int id, [FromServices] AdventureFiapContext context) =>
{
    return await context.Products.FindAsync(id);
})
.WithName("Get Products By ID")
.WithOpenApi();

app.Run();