using InventoryManagementApi.Helpers;
using InventoryManagementDataLayer.Data;
using InventoryManagementDataLayer.Interface;
using InventoryManagementDataLayer.Repository;
using InventoryManagementServiceLayer.Interface;
using InventoryManagementServiceLayer.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var inventoryRepository = new ProductRepository();
builder.Services.Add(new ServiceDescriptor(typeof(IRepository), inventoryRepository));
builder.Services.Add(new ServiceDescriptor(typeof(IProductService), new ProductService(inventoryRepository)));
builder.Services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// global error handler
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseCors("ApiCorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
