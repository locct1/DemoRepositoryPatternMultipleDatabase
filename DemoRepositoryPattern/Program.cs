using DemoRepositoryPattern.Data;
using DemoRepositoryPattern.Interfaces;
using DemoRepositoryPattern.Repositories;
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


//builder.Services.AddDbContext<AppDbContextSqlServer>();
//builder.Services.AddScoped<DbContext, AppDbContextSqlServer>();

//builder.Services.AddDbContext<AppDbContextMySql>();
//builder.Services.AddScoped<DbContext, AppDbContextMySql>();

builder.Services.AddDbContext<AppDbContextPostGre>();
builder.Services.AddScoped<DbContext, AppDbContextPostGre>();

#region Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
#endregion
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
var app = builder.Build();

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
