using DemoRepositoryPattern.Data;
using DemoRepositoryPattern.Interfaces;
using DemoRepositoryPattern.Middleware;
using DemoRepositoryPattern.Services;
using DemoRepositoryPattern.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddUnitOfWork<AppDbContext>();


#region Repositories
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
#endregion
var app = builder.Build();
app.UseMyMiddlewareCheckDb();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();
