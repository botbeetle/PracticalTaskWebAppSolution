using Microsoft.EntityFrameworkCore;
using PracticalTask.WebApp.Core.DataMappers;
using PracticalTask.WebApp.Core.DataRepositories.Contracts;
using PracticalTask.WebApp.Core.DataRepositories.Contracts.BaseContracts;
using PracticalTask.WebApp.Core.DataRepositories.Repositories;
using PracticalTask.WebApp.Core.DataRepositories.Repositories.BaseRepositories;
using PracticalTask.WebApp.Data.Contexts;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("DefaultString");

builder.Services.AddDbContext<AppDbContext>((s, options) => options.UseSqlite(connString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog((context, config) => config.WriteTo.Console().ReadFrom.Configuration(context.Configuration));

builder.Services.AddAutoMapper(typeof(DataMapper));

builder.Services.AddScoped(typeof(IDataRepository<>), typeof(DataRepository<>));
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
