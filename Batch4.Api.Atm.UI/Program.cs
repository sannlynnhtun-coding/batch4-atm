using Batch4.Api.Atm.BusinessLogic.Services;
using Batch4.Api.Atm.DataAccess.Db;
using Batch4.Api.Atm.DataAccess.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Retrieve the connection string from the configuration
string connectionString = builder.Configuration.GetConnectionString("DbConnection")!;

// Add the AppDbContext to the services with the SQL Server connection
builder.Services.AddDbContext<AppDbContext>(
    opt => { opt.UseSqlServer(connectionString); },
    ServiceLifetime.Transient,
    ServiceLifetime.Transient
);

// Add DA_Atm and BL_Atm services to the dependency injection container
builder.Services.AddScoped<DA_Atm>();
builder.Services.AddScoped<BL_Atm>();

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